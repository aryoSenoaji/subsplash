using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    [Header("Timer Settings")]
    public float maxTime;
    private float currentTime;

    [Header("UI Slider")]
    public Slider timerSlider;

    [Header("Game Manager")]
    public GameManager gameManager;

    public float timeToReduce = 5f;

    private bool isCountingDown = false;

    private void Start()
    {
        currentTime = maxTime;

        if (timerSlider != null)
        {
            timerSlider.maxValue = maxTime;
            timerSlider.value = currentTime;
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            isCountingDown = true;
        }

        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;

            if (timerSlider != null)
            {
                timerSlider.value = currentTime;
            }

            if (currentTime <= 0)
            {
                if (gameManager != null)
                {
                    gameManager.GameOver();
                }

                currentTime = maxTime;
                isCountingDown = false;
            }
        }
    }

    public void AddTime(float timeToAdd)
    {
        currentTime += timeToAdd;
        currentTime = Mathf.Min(currentTime, maxTime);
    }

    // Overload untuk menerima argumen waktu yang akan dikurangi
    public void ReduceTime(float timeToReduce)
    {
        currentTime -= timeToReduce;
        currentTime = Mathf.Max(currentTime, 0f);
    }
}
