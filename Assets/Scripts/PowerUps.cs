using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float fall;
    
    public Paddle paddle;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fall * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            paddle = collision.GetComponent<Paddle>();
            if (paddle != null)
            {
                powerUp(paddle);
            }

            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Bottom"))
        {
            Destroy(gameObject);
        }
    }

    private void powerUp(Paddle paddle)
    {
        if(gameObject.tag == "Life+")
        {
            //manager = FindObjectOfType<GameManager>();
            //manager.addLife();

            FindObjectOfType<GameManager>().addLife();
            
        }
        else if (gameObject.tag == "Size+")
        {
            paddle.increaseSize();
        }
        else if (gameObject.tag == "Size-")
        {
            paddle.decreaseSize();
        }
    }
}
