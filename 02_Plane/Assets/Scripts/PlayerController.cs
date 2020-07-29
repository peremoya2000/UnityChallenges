using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0,50), SerializeField]
    public float vTurnSpd = 20.0f;
    [Range(0,50), SerializeField]
    public float hTurnSpd = 20.0f;
    [Range(0,100), SerializeField]
    public float maxFwdSpd = 40.0f;
    private float horizontalInput,verticalInput,fwdSpd=20.0f;

    // Update is called once per frame
    void Update()
    {
        //Get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        fwdSpd += Input.GetAxis("Jump")*0.1f;
        
        //Move forward
        fwdSpd = Mathf.Clamp(fwdSpd,0, maxFwdSpd)*0.999f;
        transform.Translate(Vector3.forward * (fwdSpd*Time.deltaTime));
        //Rotate propeller
        transform.GetChild(0).Rotate(Vector3.forward,fwdSpd);
        
        //Turn up/down
        transform.Rotate(Vector3.up * (hTurnSpd*Time.deltaTime*horizontalInput));
        
        //Turn left/right
        transform.Rotate(Vector3.right * (vTurnSpd*Time.deltaTime*verticalInput));
    }
}
