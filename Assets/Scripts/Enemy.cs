using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private Player _player;

    private Animator _onDeathAnimator;

    [SerializeField]
    private AudioClip _explosionSound;

    [SerializeField]
    private GameObject _enemyLaser;

    [SerializeField]
    private float _fireRate = 0.5f;

    private float _canFile = -1f;


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
        if (Time.time > this._canFile)
        {
            _fireRate = UnityEngine.Random.Range(3f, 7f);

            _canFile = Time.time + _fireRate;

            var laserObject = Instantiate(this._enemyLaser, this.transform);
        }
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
    }

    private void ExplodeSelf()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;

        AudioSource.PlayClipAtPoint(this._explosionSound, this.transform.position);

        Destroy(this.gameObject, 2.8f);
    }

    private void HandlePlayerLaser(Collider2D other)
    {
        if (this._player == null)
            return;

        this._player.AddScore(10);

        this._onDeathAnimator.SetTrigger("OnEnemyDeath");
        
        Destroy(other.gameObject);

        this.ExplodeSelf();
    }

    private void HandlePlayerCollision(Collider2D other)
    {
        if (this._player != null)
        {
            this._player.TakeLife();

            this._onDeathAnimator.SetTrigger("OnEnemyDeath");

            Debug.Log("Player Lives: " + this._player.GetLives());

            this.ExplodeSelf();
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
