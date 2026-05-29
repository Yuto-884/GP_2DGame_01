using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    public float speed = 5f;
    public float jumpPower = 10f;

    bool isGrounded;

    int jumpCount = 0;
    int maxJump = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        Flip();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(
            x * speed,
            rb.linearVelocity.y
        );
    }

    void Jump()
    {
        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                0
            );

            rb.AddForce(
                Vector2.up * jumpPower,
                ForceMode2D.Impulse
            );

            jumpCount++;
        }
    }

    void Flip()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (x > 0)
        {
            sr.flipX = false;
        }
        else if (x < 0)
        {
            sr.flipX = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}