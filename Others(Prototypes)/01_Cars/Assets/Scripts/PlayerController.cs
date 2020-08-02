using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0,25), SerializeField]
    public float spd = 10.0f;
    [Range(0,25), SerializeField]
    public float turnSpd = 5.0f;
    private float horizontalInput,verticalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * (spd*Time.deltaTime*verticalInput));
        transform.Rotate(Vector3.up * (turnSpd*Time.deltaTime*horizontalInput));
    }
}
