using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public float spd = 1000.0f;
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.GameOver) {
            transform.Rotate(Vector3.up,Time.deltaTime*spd);
        }
        
    }
}
