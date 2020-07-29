using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveDir;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private Quaternion myRot=Quaternion.identity;
    private AudioSource _audioSource;

    [SerializeField]
    private float turnSpd=15.0f;

    private static readonly int AnimIsWalking = Animator.StringToHash("isWalking");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        moveDir.Set(hInput,0,vInput);
        moveDir.Normalize();

        bool isWalking = !Mathf.Approximately(hInput, 0) 
                        || !Mathf.Approximately(vInput,0);
        
        _animator.SetBool(AnimIsWalking,isWalking);
        if (isWalking) {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }

            Vector3 newDir=Vector3.RotateTowards(transform.forward, 
                moveDir, turnSpd * Time.fixedDeltaTime, 0f);
            myRot=Quaternion.LookRotation(newDir); 
        }
        else
        {
            _audioSource.Stop();
        }
    }

    private void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position+moveDir*_animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(myRot);
    }
}
