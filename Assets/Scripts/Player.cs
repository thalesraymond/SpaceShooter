using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right);
    }
}
