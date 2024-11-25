using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public float ballSpeed;
    private GameManager gameManager;

    public Transform ballSpawn;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        
        //this will give the player a second before the game starts
        Invoke(nameof(setTrajectory), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void setTrajectory()
    {
        Vector2 trajectory = Vector2.zero;

        trajectory.x = Random.Range(-1, 1);
        trajectory.y = -1;

        //had to add normalized beacuse was getting ball speed that was too fast.
        ballRigidbody.AddForce(trajectory.normalized * ballSpeed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
        {

            //FindObjectOfType<GameManager>().loseLife();
            
            //Destroy(this.gameObject);
        }




        if(collision.gameObject.CompareTag("Brick"))
        {
            

            BrickController brickController = collision.gameObject.GetComponent<BrickController>();

            //because of the bouncy property I have given the ball it has to move before the brick
            //is destroyed where as before it was destroying as it hit the brick which was
            //messing with the bouncy property

            if (brickController != null)
            {
                brickController.brickHit();
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
        {

            //gameManager.loseLife();

            FindObjectOfType<GameManager>().loseLife();


            transform.position = ballSpawn.transform.position;

            Invoke(nameof(setTrajectory), 1);
            //Destroy(this.gameObject);


        }

    }

    public void end()
    {
        Destroy(this.gameObject);
    }
}
