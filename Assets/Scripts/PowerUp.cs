using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    [SerializeField]
    private PowerUpType _powerUpType;

    // Start is called before the first frame update
    void Start()
    {
        this.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Player") {
            Debug.Log("Not a player");
            return;
        }

        switch(this._powerUpType)
        {
            case PowerUpType.TripeShot:
                other.gameObject.GetComponent<Shoot>().AddTripeShotAmmo();
                Destroy(this.gameObject);
                break;
            case PowerUpType.Speed:
                other.gameObject.GetComponent<Player>().EnableSpeedBoost();
                Destroy(this.gameObject);
                break;
            case PowerUpType.Shield:
                other.gameObject.GetComponent<Player>().EnableShield();
                Destroy(this.gameObject);
                break;                
        }
    }

    private void Spawn()
    {
        var powerUpPosition = Random.Range(Player.LeftBoundarie, Player.RightBoundarie);

        this.transform.position = new Vector3(powerUpPosition, 8, 0);
    }

    private void Move()
    {
        var movimentVector = this._speed * Time.deltaTime * Vector3.down;

        transform.Translate(movimentVector);

        if (this.transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }
}
