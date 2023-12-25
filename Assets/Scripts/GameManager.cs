using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    private int score;

    public GameObject gameOverUI;
    static int highScore;
    public TextMeshProUGUI highScore2;

    public void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScore2.text = highScore.ToString();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);

        scoreText2.text = score.ToString();

        if (highScore <= score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
       

    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    
}
