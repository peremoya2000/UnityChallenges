using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    public float jumpForce=60.0f;
    public ParticleSystem explosion,dust;
    private bool isOnGround=true;
    private bool _gameOver;
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip jumpSound, crashSound;
    private const string SPEED_F = "Speed_f";
    private const string JUMP = "Jump_trig";
    private const string DEATH = "Death_b";
    private const string DEATH_TYPE = "DeathType_int";

    public bool GameOver{get => _gameOver;}

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat(SPEED_F,(0.4f+Time.time/10));
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            _playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dust.Stop();
            _animator.SetTrigger(JUMP);
            _audioSource.PlayOneShot(jumpSound,1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Terrain")) {
            isOnGround = true;
            if(!_gameOver)dust.Play();
        }else if(other.gameObject.CompareTag("Obstacle")){
            _gameOver = true;
            _animator.SetBool(DEATH, true);
            _animator.SetInteger(DEATH_TYPE, Random.Range(1,3));
            explosion.Play();
            dust.Stop();
            _audioSource.PlayOneShot(crashSound,1);
            Invoke("RestartGame",4.0f);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Prototype 3");
    }
}
