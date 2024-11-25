using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameManager gameManger;
    //public TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resumeGame()
    {
        gameManger.resumeGame();
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level01");

    }

    public void menu()
    {
        SceneManager.LoadScene("Main Menu");
    }




}

