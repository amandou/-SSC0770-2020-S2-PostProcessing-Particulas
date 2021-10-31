using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontalMovement;
    public float dashSpeed = 30f;
    public float speed = 10f;

    private Rigidbody2D rb;
    private bool canMove = true;
    private bool canDash = true;

    public ParticleSystem dashEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        Walk();
        Flip();
        Dash();

    }

    private void Walk()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(horizontalMovement * speed , rb.velocity.y);
        }
    }

    private void Flip()
    {
        if (horizontalMovement > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (horizontalMovement < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void Dash()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        if (canDash && Input.GetKey(KeyCode.Z))
        {
            Debug.Log("Dash");
            canDash = false;
            canMove = false;
            dashEffect.Play();
            Invoke("CanDashTimer", 0.5f);
            Invoke("CanMoveTimer", 0.2f);
            rb.velocity = new Vector2(horizontalMovement * dashSpeed, rb.velocity.y);

        }

    }

    void CanMoveTimer()
    { 
        canMove = true;
    }
    void CanDashTimer()
    {
        canDash = true;
    }
}
