using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System;
using TMPro;

public class LogicScript : MonoBehaviour


{
    public int playerScore;
    public int highScore;
    public Text ScoreText;
    public float Score;
    public Text HighScoreText;
    public float HighScore;
    public GameObject Bird;
    public GameObject gameOverScreen;
    public GameObject PausePanel;
    private bool gameRunning;
    public GameObject PauseButton;
    public AudioSource MusicSource;
    private BirdScript bird;

    AudioManager audioManager;
    
    void Start()
    {
        Score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);    
        bird = FindAnyObjectByType<BirdScript>();

        if(PlayerPrefs.HasKey("HighScore"))
        {
            HighScore = PlayerPrefs.GetFloat("HighScore");
        }

        else

        {
            HighScore = 0;
        }
    }

    private void OnTrggerExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Score")
        {
            playerScore++;
            if(playerScore > highScore)
            {
                PlayerPrefs.SetInt("HighScore", playerScore);
            }
        }
    }

    public int GetScore()
    {
        return playerScore;
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Time.timeScale = 1f;

        HighScoreText.text = "HighScore:" + PlayerPrefs.GetInt("HighScore", 0);
    }


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        audioManager.PlaySFX(audioManager.score);
        playerScore = playerScore + scoreToAdd;
        ScoreText.text = playerScore.ToString();
        var number = ScoreText;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        audioManager.PlaySFX(audioManager.wallTouch);
        audioManager.PlaySFX(audioManager.death);
        MusicSource.Stop();
        gameOverScreen.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    public void Quitgame()
    {
        Application.Quit();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameRunningState();
        }

        HighScoreText.text = HighScore.ToString();
        ScoreText.text = Score.ToString();

        if(bird == null)
        {
            SaveScore();
        }
    }

    public void SaveScore()
    {
        if(Score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", Score);
        }
    }

    public void ChangeGameRunningState()
    {
        gameRunning = !gameRunning;

        if(gameRunning)
        {
            //Game is Running
            Debug.Log("Game Running");
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Play();
            }
        }
        else
        {
            //Game is Paused
            Debug.Log("Game Paused");
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        }
    }
}
