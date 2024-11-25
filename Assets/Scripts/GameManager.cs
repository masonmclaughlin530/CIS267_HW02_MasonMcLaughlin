using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public int level;

    public GameObject pauseMenu;
    public TMP_Text finalScoreText;
    private Score playerScore;
    public GameObject gameOverMenu;
    private bool playGame = true;
    public TMP_Text livesText;


    public GameObject ball;
    public Transform ballSpawn;
    // Start is called before the first frame update
    void Start()
    {
        //newGame();
        playerScore = gameObject.GetComponent<Score>();
        playGame = true;

    }

    // Update is called once per frame
    void Update()
    {
        pauseButton();

        if(lives == 0)
        {
            int finalScore = playerScore.finalScore();
            endGame(finalScore);
            Time.timeScale = 0;
        }
    }

    private void Awake()
    {
       // DontDestroyOnLoad(this.gameObject);
    }


    private void newGame()
    {
        this.score = 0;
        this.lives = 3;
    }

    private void loadLevel()
    {
        //level = Random.Range(1, 2);

        //SceneManager.LoadScene("level0" + level);
    }

    public void loseLife()
    {
        lives--;
        Debug.Log(lives);
        updateLivesText();

        if (lives <= 0)
        {
            FindObjectOfType<Ball>().end();
            playGame = false;
            endGame(playerScore.finalScore());

        }
        else
        {
            respawn();
        }

    }

    private void updateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }

    public void pauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void endGame(int finalScore)
    {
        finalScoreText.text = "Final Score: " + finalScore;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void restart()
    {
        Time.timeScale = 1;
        newGame();
        SceneManager.LoadScene("Level01");
    }

    private void respawn()
    {
        //GameObject newBall = Instantiate(ball, ballSpawn.position, Quaternion.identity);
    }


    public void addLife()
    {
        lives++;
        updateLivesText();

        //Console.WriteLine(lives);

        Debug.Log(lives);
    }



    
      






}
