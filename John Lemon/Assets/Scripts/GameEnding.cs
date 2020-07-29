using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration=1.0f;
    public float waitToEnd=0.5f;
    private bool exiting,playerCaught;
    private float timer;
    private bool audioPlayed;
    

    public GameObject player;
    public CanvasGroup exitImageCanvasGroup;
    public CanvasGroup caughtImageCanvasGroup;
    public AudioSource loseAudio, winAudio;

    private void Update()
    {
        if (exiting)
        {
            EndLevel(exitImageCanvasGroup,false,winAudio);
        }else if (playerCaught)
        {
            EndLevel(caughtImageCanvasGroup,true,loseAudio);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            exiting = true;
        }
    }
    /// <summary>
    /// Displays game end image
    /// </summary>
    /// <param name="image"></param>
    private void EndLevel(CanvasGroup image, bool restart, AudioSource audioSource)
    {
        if (!audioPlayed)
        {
            audioSource.Play();
            audioPlayed = true;
        }
        
        timer += Time.deltaTime;
        image.alpha = timer / fadeDuration;
        if (timer > fadeDuration+waitToEnd)
        {
            if (restart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }else {
                Application.Quit(); 
            }
        }
    }

    public void CatchPlayer()
    {
        playerCaught = true;
    }
}

