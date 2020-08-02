using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float moveForce = 5.0f;
    private Rigidbody _rigidbody;
    private GameObject _focalPoint;
    private bool _powerUp;
    public float powerUpForce;
    public float powerUpDuration;
    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _focalPoint= GameObject.Find("Center");
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Vertical");
        _rigidbody.AddForce(_focalPoint.transform.forward * (moveForce * input));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _powerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
        }else if (other.CompareTag("NukePowerUp"))
        {
            Destroy(other.gameObject);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Vector3 away = (enemy.transform.position - transform.position).normalized;
                enemy.GetComponent<Rigidbody>().AddForce(away*powerUpForce*2.0f,ForceMode.Impulse);
            }
        }
        else if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_powerUp && other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 repulsionDir = other.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(repulsionDir*powerUpForce,ForceMode.Impulse);
            
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        powerUpIndicator.SetActive(false);
        _powerUp = false;
    }
    
}
