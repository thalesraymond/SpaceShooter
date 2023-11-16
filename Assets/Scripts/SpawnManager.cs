using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject _powerUpContainer;

    [SerializeField]
    private GameObject[] _powerUps;

    [SerializeField]
    private float minEnemySpawnInterval = 0.5f;

    [SerializeField]
    private float maxEnemySpawnInterval = 2f;

    [SerializeField]
    private float minPowerUpSpawnInterval = 5f;

    [SerializeField]
    private float maxPowerUpSpawnInterval = 10f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());

        StartCoroutine(SpawnPowerUps());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnEnemies()
    {
        var player = this._player.GetComponent<Player>();

        if(player == null)
        {
            yield break;
        }

        while(player.IsAlive())
        {
            var nextCheck = Random.Range(this.minEnemySpawnInterval, this.maxEnemySpawnInterval);

            var enemyObject = Instantiate(this._enemyPrefab);

            enemyObject.transform.parent = this._enemyContainer.transform;

            yield return new WaitForSeconds(nextCheck);
        }
    }

    IEnumerator SpawnPowerUps()
    {
        var player = this._player.GetComponent<Player>();

        if (player == null)
        {
            yield break;
        }

        while (player.IsAlive())
        {
            var nextCheck = Random.Range(this.minPowerUpSpawnInterval, this.maxPowerUpSpawnInterval);

            var powerUpSelector = Random.Range(0, this._powerUps.Length);

            var powerUpObject = Instantiate(this._powerUps[powerUpSelector]);

            powerUpObject.transform.parent = this._powerUpContainer.transform;

            yield return new WaitForSeconds(nextCheck);
        }
    }
}
