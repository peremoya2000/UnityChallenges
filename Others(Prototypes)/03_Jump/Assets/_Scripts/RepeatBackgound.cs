using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeatBackgound : MonoBehaviour
{
    private Vector3 startPos;
    private float hWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        hWidth = (GetComponent<BoxCollider>().size.x/2);
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x - transform.position.x>hWidth)
        {
            transform.position = startPos;
        }
    }
}
