using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float moveForce = 2.0f;
    private GameObject _target;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _target=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToTarget = (_target.transform.position - transform.position).normalized;
        dirToTarget.y = 0;
        _rigidbody.AddForce(dirToTarget * moveForce);
        if (transform.position.y < -15) {
            Destroy(gameObject);
        }
    }
}
