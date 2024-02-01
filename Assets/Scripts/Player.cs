using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    AudioManager audioManager; 

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strenght = 5f;

    private bool gameStarted = false;

    public GameObject spawner;

    private void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
                spawner.SetActive(true);
            }
            else
            {
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strenght;
            audioManager.PlaySFX(audioManager.jump);
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
            audioManager.PlaySFX(audioManager.death);
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            audioManager.PlaySFX(audioManager.score);
        }
        else if (other.gameObject.CompareTag("Ranjau"))
        {
            // Menyentuh ranjau, kurangi waktu pada komponen Oxygen
            Oxygen oxygen = FindObjectOfType<Oxygen>();
            if (oxygen != null)
            {
                // Panggil metode ReduceTime() pada Oxygen dengan nilai timeToReduce dari Oxygen
                oxygen.ReduceTime(oxygen.timeToReduce);
                audioManager.PlaySFX(audioManager.ranjau);
            }
        }
    }
}
