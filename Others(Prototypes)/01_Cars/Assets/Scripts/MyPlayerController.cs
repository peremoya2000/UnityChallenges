using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class MyPlayerController : MonoBehaviour
{
    private float forwardSpd=0;
    public float turnSpd=0.2f;
    private float hInput, vInput;
    public float maxSpd = 30.0f;

    // Update is called once per frame
    void Update()
    {
        //Get input
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        
        //Rotate left/right
        transform.Rotate(Vector3.up * (hInput*turnSpd*Math.Abs(forwardSpd)/maxSpd));
        
        //Move in a line
        forwardSpd += (vInput*0.1f);
        forwardSpd = Mathf.Clamp(forwardSpd, -20.0f, maxSpd)*0.999f;
        transform.Translate(Vector3.forward * (forwardSpd*Time.deltaTime));
    }
}
