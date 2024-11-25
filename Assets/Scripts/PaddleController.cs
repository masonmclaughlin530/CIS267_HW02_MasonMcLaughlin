using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public Vector2 direction;
    public float paddleSpeed;
    public float maxBounceAngle = 75;
    public GameObject sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.direction = Vector2.right;
        }
        else
        {
            this.direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (this.direction != Vector2.zero)
        {
            this.playerRigidbody.AddForce(this.direction * paddleSpeed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ball"))
        {
            //found this way to for the ball to bounce
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, collision.rigidbody.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            //limits the max angle that the ball can bounce to
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            //quaternion is used for rotations
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

            collision.rigidbody.velocity = rotation * Vector2.up * collision.rigidbody.velocity.magnitude;
        }
    }


    public void increaseSize()
    {
        sprite.transform.localScale = new Vector3(.5f, .5f, 1);
    }

    public void decreaseSize()
    {
        sprite.transform.localScale = new Vector3(.1f, .1f, 1);
    }




}
