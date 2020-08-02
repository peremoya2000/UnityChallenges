using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForeward : MonoBehaviour
{
    public float spd = 30.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (spd * Time.deltaTime));   
    }
}
