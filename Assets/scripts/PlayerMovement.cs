using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform floorCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        jumpCount = maxJumpCount;
    }

    private void Update()
    {
        ProcessInputs();
        Animate();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(floorCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        Movement();
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }
    private void Movement()
    {
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
        if (isJumping && jumpCount > 0)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jumpCount--;
        }
        if(!isGrounded && jumpCount == maxJumpCount)
        {
            jumpCount--;
        }
        isJumping= false;
    }
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }
    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
