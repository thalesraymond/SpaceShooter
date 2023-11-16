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
        var enemyPosition = Random.Range(-9.5f, 9.5f);

        this.transform.position = new Vector3(enemyPosition, 8, 0);
    }
}
