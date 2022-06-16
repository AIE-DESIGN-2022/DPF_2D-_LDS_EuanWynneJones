using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject enemyPrefab;

    public GameObject SpawnEmemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation);
        newEnemy.transform.parent = transform;
        Debug.Log("Spawning Enemy");

        return newEnemy;
    }
}
