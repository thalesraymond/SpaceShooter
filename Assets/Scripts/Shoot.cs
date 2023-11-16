using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripeLaserPrefab;

    [SerializeField]
    private float _laserOffset = 0;

    [SerializeField]
    private float _fireRate = 0.5f;

    private float _canFile = -1f;

    [SerializeField]
    private bool _isTripeShotEnabled = false;

    [SerializeField]
    private int _tripeShotAmmo = 0;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > this._canFile)
        {
            this._canFile = Time.time + this._fireRate;

            if(this._isTripeShotEnabled)
            {
                this.ShootTripleLaser();
            }
            else
            {
                this.ShootSingleLaser();
            }     
            
        }
    }

    public void AddTripeShotAmmo()
    {
        this._isTripeShotEnabled = true;

        this._tripeShotAmmo = 10;
    }

    private void ShootSingleLaser()
    {
        var laserInitialPosition = this.transform.position + new Vector3(0, this._laserOffset, 0);

        Instantiate(this._laserPrefab, laserInitialPosition, Quaternion.identity);
    }

    private void ShootTripleLaser()
    {
        var laserInitialPosition = this.transform.position + this._tripeLaserPrefab.transform.position;

        Instantiate(this._tripeLaserPrefab, laserInitialPosition, Quaternion.identity);

        this._tripeShotAmmo--;

        this._isTripeShotEnabled = this._tripeShotAmmo > 0;
    }
}
