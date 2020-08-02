using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private float rotDir;
    public float rotSpd = 45.0f;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        rotDir = Input.GetMouseButton(0)? rotSpd : 0.0f;
        rotDir-= Input.GetMouseButton(1)? rotSpd : 0.0f;

        transform.Rotate(Vector3.up,rotDir*Time.deltaTime);
    }
}
