using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
         transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * this.Speed * Time.deltaTime * Input.GetAxis("Horizontal"));

        //transform.Translate(Vector3.up * this.Speed * Time.deltaTime * Input.GetAxis("Vertical"));

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var movimentVector = this.Speed * Time.deltaTime * new Vector3(horizontalInput, verticalInput);

        transform.Translate(movimentVector);
    }
}
