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
        this.Respawn();        
    }

    // Update is called once per frame
    void Update()
    {
        this.MoveEnemy();
    }

    private void OnTriggerEnter(Collider other)
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

        this.Respawn();
    }

    private void HandlePlayerCollision(Collider other)
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
            this.Respawn();
        }
    }

    private void Respawn()
    {
        var enemyXPosition = UnityEngine.Random.Range(Player.LeftBoundarie, Player.RightBoundarie);

        this.transform.position = new Vector3(enemyXPosition, 8, 0);
    }
}
