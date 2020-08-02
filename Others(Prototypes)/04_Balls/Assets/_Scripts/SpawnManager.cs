using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerUpPrefabs;
    private float spawnRange = 9.0f;
    private int enemyCount;
    private short wave = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(wave);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(++wave);
        }
    }
    /// <summary>
    /// Generate a random point inside the 2d area defined by spawnRange
    /// </summary>
    /// <returns>Random point within spawnRange</returns>
    private Vector3 GenerateSpawnPoint()
    {
        Vector3 spawnPoint= new Vector3(
            Random.Range(-spawnRange,spawnRange),
            0 ,
            Random.Range(-spawnRange,spawnRange));
        return spawnPoint;
    }

    /// <summary>
    /// Spawn the specified ammount of enemies
    /// </summary>
    /// <param name="ammount">Enemies to spawn</param>
    private void SpawnEnemyWave(short ammount) {
        for (short i = 0; i < ammount; ++i) {
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
            if (wave % 2 == 0 && i%2==0 && Random.value>0.3f)
            {
                int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);
                Instantiate(powerUpPrefabs[powerUpIndex], GenerateSpawnPoint(), powerUpPrefabs[powerUpIndex].transform.rotation);
            }
        }
    }
}
