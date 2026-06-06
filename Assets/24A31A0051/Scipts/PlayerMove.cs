using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    public float speed = 5f;
    public float jumpPower = 10f;

    bool isGrounded;

    int jumpCount = 0;
    int maxJump = 2;

    public int life = 30;

    public float minX = 0f;
    public float maxX = 50f;

    public float minY = -5f;
    public float maxY = 20f;

    public GameObject gameOverPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isGrounded = true;
    }

    void Update()
    {
        Debug.Log(GameManager.Instance.isStarted);

        if (!GameManager.Instance.isStarted)
            return;

        Move();
        Jump();
        Flip();

        animator.SetBool("isJumping", !isGrounded);

        ClampPosition();

        // 落下判定
        if (transform.position.y < -8)
        {
            Die();
        }

        if (life <= 0)
        {
            GameOver();
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(
            x * speed,
            rb.linearVelocity.y
        );

        animator.SetFloat("xVelocity", Mathf.Abs(x));
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= 10;

            Debug.Log("残りライフ：" + life);
        }
    }

    void ClampPosition()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    void Die()
    {

        life -= 10;

        Debug.Log("残りライフ：" + life);

        // とりあえずスタート地点へ戻す
        transform.position = new Vector3(-9.07f, 2.79f, 0f);

        rb.linearVelocity = Vector2.zero;
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}