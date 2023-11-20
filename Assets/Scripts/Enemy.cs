using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private Player _player;

    private Animator _onDeathAnimator;


    // Start is called before the first frame update
    void Start()
    {
        this.Spawn();

        this._player = GameObject.Find("Player").GetComponent<Player>();

        this._onDeathAnimator = this.GetComponent<Animator>();
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
                this.HandlePlayerLaser(other);
                break;
        }

        this.GetComponent<BoxCollider2D>().enabled = false;

        Destroy(this.gameObject, 2.8f);
    }

    private void HandlePlayerLaser(Collider2D other)
    {
        if (this._player == null)
            return;

        this._player.AddScore(10);

        this._onDeathAnimator.SetTrigger("OnEnemyDeath");

        
        Destroy(other.gameObject);
    }

    private void HandlePlayerCollision(Collider2D other)
    {
        if (this._player != null)
        {
            this._player.TakeLife();

            this._onDeathAnimator.SetTrigger("OnEnemyDeath");

            Debug.Log("Player Lives: " + this._player.GetLives());
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
