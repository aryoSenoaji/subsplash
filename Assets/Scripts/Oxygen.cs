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
    public GameManager gameManager; // Tambahkan reference ke GameManager

    private bool isCountingDown = false;

    private void Start()
    {
        // Set nilai awal timer
        currentTime = maxTime;

        // Set nilai awal slider
        if (timerSlider != null)
        {
            timerSlider.maxValue = maxTime;
            timerSlider.value = currentTime;
        }
    }

    private void Update()
    {
        // Cek apakah player memberikan input
        if (Input.anyKeyDown)
        {
            isCountingDown = true;
        }

        // Jalankan CountdownTimer hanya jika isCountingDown true
        if (isCountingDown)
        {
            // Kurangi waktu
            currentTime -= Time.deltaTime;

            // Update nilai slider
            if (timerSlider != null)
            {
                timerSlider.value = currentTime;
            }

            // Cek jika waktu habis
            if (currentTime <= 0)
            {
                // Panggil fungsi GameOver pada GameManager
                if (gameManager != null)
                {
                    gameManager.GameOver();
                }

                // Reset timer ke nilai awal
                currentTime = maxTime;
                isCountingDown = false; // Berhenti menghitung ketika waktu habis
            }
        }
    }

    // Menambah waktu ke timer
    public void AddTime(float timeToAdd)
    {
        currentTime += timeToAdd;

        // Pastikan waktu tidak melebihi maksimum
        currentTime = Mathf.Min(currentTime, maxTime);
    }
}
