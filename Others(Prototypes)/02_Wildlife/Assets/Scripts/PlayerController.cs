using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float hInput;
    public float spd = 15.0f;
    public float xRange = 16.0f;
    public GameObject prectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*(hInput*spd*Time.deltaTime));

        var position = transform.position;
        position = new Vector3(Mathf.Clamp(position.x, -xRange, xRange),
                                        position.y,
                                        position.z);
        transform.position = position;

        //Character actions
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prectilePrefab, transform.position, prectilePrefab.transform.rotation);
        }
    }
}
