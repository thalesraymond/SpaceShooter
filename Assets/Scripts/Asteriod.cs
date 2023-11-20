using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 10.0f;

    [SerializeField]
    private GameObject _explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var movimentVector = this._rotationSpeed * Time.deltaTime * Vector3.forward;

        this.transform.Rotate(movimentVector);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Laser")
            return;

        var explosionObject = Instantiate(this._explosion, this.transform.position, Quaternion.identity);
        
        Destroy(other.gameObject);

        Destroy(this.gameObject, 0.2f);


    }
}
