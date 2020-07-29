using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -35.0f;
    private float bottomLimit = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftLimit || transform.position.y < bottomLimit) {
            Destroy(gameObject);
        }

    }
}
