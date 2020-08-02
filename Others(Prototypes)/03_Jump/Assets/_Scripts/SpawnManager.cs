using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;
    private float spawnInterval = 4.0f;
    private float elapsedTime=0.0f;
    private Vector2 spawnBounds = new Vector2(1.1f,5.0f);
    private int index;
    private PlayerController _playerController;
    
    private void Start()
    {
        spawnPos = this.transform.position;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnInterval && !_playerController.GameOver) {
            elapsedTime = 0.0f;
            spawnInterval = Random.Range(spawnBounds.x, spawnBounds.y);
            //Spawn
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        index = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[index], spawnPos, obstaclePrefabs[index].transform.rotation);
    }
}
