using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesPrefabs;
    [SerializeField] GameObject[] spawnAreas;

    private Round round;

    void Start()
    {
        round = FindObjectOfType<Round>();
    }

    private void Update() 
    {
        if(GameObject.FindWithTag("Enemy") == null) 
        {  
            round.IncreamentCurrentRound();
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < round.GetNoOfEnimes(); i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject areaToSpawn = spawnAreas[Random.Range(0, spawnAreas.Length)];
        GameObject enemyToSpawn = enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)];
        Vector3 coordinatesToSpawn = new Vector3
                                                (   
                                                    Random.Range(areaToSpawn.transform.position.x - areaToSpawn.transform.localScale.x / 2,
                                                                 areaToSpawn.transform.position.x + areaToSpawn.transform.localScale.x / 2),
                                                    enemyToSpawn.transform.position.y,
                                                    Random.Range(areaToSpawn.transform.position.z - areaToSpawn.transform.localScale.z / 2,
                                                                 areaToSpawn.transform.position.z + areaToSpawn.transform.localScale.z / 2)
                                                );
        Instantiate(enemyToSpawn,coordinatesToSpawn,enemyToSpawn.transform.rotation);
    }
}
