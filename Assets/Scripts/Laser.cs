using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 9f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var movimentVector = this._speed * Time.deltaTime * Vector3.up;

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
