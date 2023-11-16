using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _laserOffset = 0;

    [SerializeField]
    private float _fireRate = 0.5f;

    private float _canFile = -1f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > this._canFile)
        {
            this._canFile = Time.time + this._fireRate;

            var laserInitialPosition = this.transform.position + new Vector3(0, this._laserOffset, 0);

            Instantiate(this._laserPrefab, laserInitialPosition, Quaternion.identity);
        }
    }
}
