using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 newPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position= new Vector3(newPos.x,newPos.y);
    }
}
