using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform feetPosition;
    public LayerMask whatIsGround;

    public float jumpForce = 5f;
    public float fallMultiplier = 30f;
    public float lowJumpMultiplier = 20f;
    public float checkRadius;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetButton("Jump"))
        {
            Jump();
        }
        GravitySimulator();
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void GravitySimulator()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
