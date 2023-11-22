using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 9f;

    [SerializeField]
    private AudioClip _laserSound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(this._laserSound, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        var direction = this.tag == "Laser" ? Vector2.up : Vector2.down;

        var movimentVector = this._speed * Time.deltaTime * direction;

        this.transform.Translate(movimentVector);

        if(this.transform.position.y > 10)
        {
            Destroy(this.gameObject);

            if (this.transform.parent != null)
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
}
