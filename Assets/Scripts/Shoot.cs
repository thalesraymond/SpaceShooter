using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _laserOffset = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var laserInitialPosition = this.transform.position + new Vector3(0, this._laserOffset, 0);

            Instantiate(this._laserPrefab, laserInitialPosition, Quaternion.identity);
        }
    }
}
