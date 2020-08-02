
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private byte animalIndex;
    private float zPosition;
    private float xRange = 15.0f;
    private float startDelay=2.5f;
    private float spawnInterval = 1.2f;

    private void Awake() {
        zPosition = transform.position.z;
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    private void SpawnRandomAnimal() {
        animalIndex = (byte) Random.Range(0,enemies.Length);
        Instantiate(enemies[animalIndex],
            new Vector3(Random.Range(-xRange,xRange), 0, zPosition),
            enemies[animalIndex].transform.rotation);
    }
}
