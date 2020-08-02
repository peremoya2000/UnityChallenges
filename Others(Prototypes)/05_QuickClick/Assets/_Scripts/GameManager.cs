using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        loading,
        inGame,
        gameOver
    }

    public GameState gameState;
    private short lives = 3;

    public GameObject[] targetPrefabs;
    public Image[] hearts;
    private float spawnRate=1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    private int score;
    

    private void Start()
    {
        ShowMaxScore();
    }

    IEnumerator SpawnTarget()
    {
        while (gameState==GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Length);
            Instantiate(targetPrefabs[index]);
        }
    }
    /// <summary>
    /// Increments an sets score
    /// </summary>
    /// <param name="scoreToAdd">Ammount of points to add</param>
    public void UpdateScore(short scoreToAdd)
    {
        score += scoreToAdd;
        if (score < 0)
        {
            score = 0;
            GameOver();
        }

        scoreText.text = "Score: " + score;
    }

    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt("MAX_SCORE",0);
        scoreText.text = "Max Score: " + maxScore;
    }

    /// <summary>
    /// Sets gameState to gameOver and activates game over UI
    /// </summary>
    public void GameOver()
    {
        if (--lives >= 0) {
            Image heartImage = hearts[lives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.1f;
            heartImage.color = tempColor; 
        }else{
            int maxScore = PlayerPrefs.GetInt("MAX_SCORE", 0);
            if (score > maxScore)
            {
                PlayerPrefs.SetInt("MAX_SCORE", score);
            }

            gameOverText.gameObject.SetActive(true);
            gameState = GameState.gameOver;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Start game setting gameState to inGame
    /// </summary>
    public void StartGame(float difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        foreach (Image heart in hearts) {
            heart.gameObject.SetActive(true);
        }
        gameState = GameState.inGame;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }
}
