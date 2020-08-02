using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound=30.0f;
    private float lowerBound=-10.0f;
    private float sidewaysBounds = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound ||
        transform.position.x>sidewaysBounds || transform.position.x < -sidewaysBounds ||
        transform.position.y<-10.0f)
        {
            Destroy(this.gameObject);
        }else if (transform.position.z < lowerBound)
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }
}
