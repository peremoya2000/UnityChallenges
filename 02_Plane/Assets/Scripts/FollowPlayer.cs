using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public bool rotateWithPlayer = true;
    private Vector3 offset = new Vector3(3.0f,-2.0f,-30.0f);
    


    // Update is called once per frame
    void Update()
    {
        if (rotateWithPlayer)
        {
            //position
            transform.position = player.transform.TransformPoint(offset);
            //rotate
            transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.position = player.transform.position + offset;
        }

    }
}
