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
    private float minSpawnInterval = 0.5f;

    [SerializeField]
    private float maxSpawnInterval = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
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
            var nextCheck = Random.Range(this.minSpawnInterval, this.maxSpawnInterval);

            var enemyObject = Instantiate(this._enemyPrefab);

            enemyObject.transform.parent = this._enemyContainer.transform;

            yield return new WaitForSeconds(nextCheck);
        }
    }
}
