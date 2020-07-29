using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.CompareTag("Floor"))
        {
            Time.timeScale = 0;
            Debug.Log("GAME OVER");
        }
    }
}
