using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;


    // Start is called before the first frame update
    void Start()
    {
        this.Spawn();        
    }

    // Update is called once per frame
    void Update()
    {
        this.MoveEnemy();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Player":
                this.HandlePlayerCollision(other);
                break;
            case "Laser":
                Destroy(other.gameObject);
                break;
        }

        Destroy(this.gameObject);
    }

    private void HandlePlayerCollision(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (player != null)
        {
            player.TakeLife();

            Debug.Log("Player Lives: " + player.GetLives());
        }
    }

    private void MoveEnemy()
    {
        var movimentVector = this._speed * Time.deltaTime * Vector3.down;

        transform.Translate(movimentVector);

        if (this.transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void Spawn()
    {
        var enemyXPosition = UnityEngine.Random.Range(Player.LeftBoundarie, Player.RightBoundarie);

        this.transform.position = new Vector3(enemyXPosition, 8, 0);
    }
}
