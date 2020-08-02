using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float spd=45.0f;
    private float hInput;

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, hInput*spd*Time.deltaTime);
    }
}
