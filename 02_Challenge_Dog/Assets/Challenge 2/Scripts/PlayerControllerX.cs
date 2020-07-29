using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float coolDown=0.5f;
    private float cdCounter = 0.0f;

    // Update is called once per frame
    void Update()
    {
        cdCounter -= Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKey(KeyCode.Space) && cdCounter<=0)
        {
            cdCounter = coolDown;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
