using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public bool unbreakable;
    public int health = 1;
    public int points = 25;
    public float dropChance = .2f;


    public Score brickScore;

    public GameObject[] powerUps;

    // Start is called before the first frame update
    void Start()
    {
        brickScore = gameObject.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    

    public void brickHit()
    {
        health--;

        if(health <= 0)
        {

            //if (brickScore != null)
            //{
                //brickScore.addToScore(points);

            //}

            FindObjectOfType<Score>().addToScore(points);

            

            Destroy(gameObject);

            spawnPowerUp();

        }
 
    }

    public void spawnPowerUp()
    {
        if (Random.Range(0,100) < 30)
        {
            int i = Random.Range(0,powerUps.Length);
            Instantiate(powerUps[i], transform.position, Quaternion.identity);
        }
    }



}


