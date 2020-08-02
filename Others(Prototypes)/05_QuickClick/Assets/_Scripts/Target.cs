using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public ParticleSystem explosionParticle;
    private Vector2 forceRange= new Vector2(11.0f,18.0f);
    private float xRange = 4.0f,
                yPos = -5.0f,
                maxTorque=10.0f;
    private GameManager gameManager;
    [Range(-100,100)]
    public short pointsValue;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        
        transform.position= new Vector3(Random.Range(-xRange,xRange),yPos);
        
        _rigidbody.AddForce(RandomForce(),ForceMode.Impulse);
        Vector3 torque = RandomTorque();
        _rigidbody.AddTorque(torque.x, torque.y, torque.z,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.gameState == GameManager.GameState.inGame) {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            gameManager.UpdateScore(pointsValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            if (gameObject.CompareTag("Good"))
            {
                gameManager.GameOver();
            }

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Creates an upwards vector with random length between the forceRange
    /// </summary>
    /// <returns>Upwards vector with length between forceRange</returns>
    private Vector3 RandomForce() {
        return Vector3.up*Random.Range(forceRange.x,forceRange.y);
    }
    /// <summary>
    /// Creates random vector for torque inside specified parameters
    /// </summary>
    /// <returns>Random torque vector</returns>
    private Vector3 RandomTorque() {
        return new Vector3(Random.Range(-maxTorque,maxTorque),
            Random.Range(-maxTorque,maxTorque),
            Random.Range(-maxTorque,maxTorque));
    }
}
