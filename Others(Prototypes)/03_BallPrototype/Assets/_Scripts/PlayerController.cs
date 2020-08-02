using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float acceleration=5.0f, jumpForce=20.0f;
    private Rigidbody _rigidbody;
    private GameObject _acolyte;
    private float vInput, hInput;
    private bool isOnGround;
    private Vector3 dir= Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _acolyte = GameObject.Find("Acolyte");
        
    }

    void FixedUpdate()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        dir = Quaternion.LookRotation(_acolyte.transform.forward)*new Vector3(hInput, 0, vInput);

        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            _rigidbody.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            isOnGround = false;
        }
        _rigidbody.AddForce(dir * acceleration);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            isOnGround = true;
        }
    }
}
