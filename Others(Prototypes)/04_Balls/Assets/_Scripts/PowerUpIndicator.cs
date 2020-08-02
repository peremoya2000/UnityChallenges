using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIndicator : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + Vector3.down * 0.4f;
    }


}
