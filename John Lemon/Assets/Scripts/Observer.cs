using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    public Transform player;
    private bool playerInRange;
    public GameEnding gameEnding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (playerInRange)
        {
            Vector3 dir = (player.position - transform.position) + Vector3.up;
            Ray ray = new Ray(transform.position,dir);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform == player)
                {
                    gameEnding.CatchPlayer();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = false;
        }
    }
}
