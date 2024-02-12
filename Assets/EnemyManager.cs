using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefab;

    private int enemyCount;

    void SpawnEnemy()
    {
        Vector3 playerPosition = player.transform.position;
        var r = Random.insideUnitCircle;
        var spawn = r.normalized * 5 + r * 10;
        Vector3 spawnPosition = new Vector3(playerPosition.x + spawn.x, 0.5f, playerPosition.z + spawn.y);
        var spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemyCount++;
        spawnedEnemy.GetComponent<EnemyController>().player = player.transform;
        spawnedEnemy.GetComponent<EnemyController>().enemyManager = this;
    }

    public void OnDeath(EnemyController enemyController)
    {
        enemyCount--;
        SpawnEnemy();
        SpawnEnemy();


    }

    private void Start()
    {
        SpawnEnemy();
    }

}
