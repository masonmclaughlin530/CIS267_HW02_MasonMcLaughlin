using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToScore(int points)
    {
        score += points;
        updateScoreText();
        Debug.Log(score);

    }

    public void updateScoreText()
    {
        scoreText.text = "Score: " + score; 
    }

    public int getScore()
    {
        return score;
    }

    public int finalScore()
    {
        return score;
    }
}
