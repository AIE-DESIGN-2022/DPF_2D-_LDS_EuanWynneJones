using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meleeSpawnLocation;
    public GameObject meleeEnemyPrefab;

    public GameObject rangedSpawnLocation;
    public GameObject rangedEnemyPrefab;

    public GameObject siegeSpawnLocation;
    public GameObject siegeEnemyPrefab;


    public GameObject SpawnEmemyMelee()
    {
        GameObject newEnemy = Instantiate(meleeEnemyPrefab, meleeSpawnLocation.transform.position, meleeSpawnLocation.transform.rotation);
        newEnemy.transform.parent = transform;
        //Debug.Log("Spawning Enemy");

        return newEnemy;
    }

    public GameObject SpawnEmemyRanged()
    {
        GameObject newEnemy = Instantiate(rangedEnemyPrefab, rangedSpawnLocation.transform.position, rangedSpawnLocation.transform.rotation);
        newEnemy.transform.parent = transform;
        //Debug.Log("Spawning Enemy");

        return newEnemy;
    }

    public GameObject SpawnEmemySiege()
    {
        GameObject newEnemy = Instantiate(siegeEnemyPrefab, siegeSpawnLocation.transform.position, siegeSpawnLocation.transform.rotation);
        newEnemy.transform.parent = transform;
        //Debug.Log("Spawning Enemy");

        return newEnemy;
    }
}
