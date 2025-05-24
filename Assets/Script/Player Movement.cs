using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Security.Cryptography;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;
public class PlayerMovement : MonoBehaviour
{
    [Header("Stats Speed")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpForceMultiplier = 15f;
    public float MaxjumpTimer = 1f;
    [Header("Gravity Scale When:")]
    [SerializeField] float GravityFalllingWithSpace;
    [SerializeField] float GravityFallling;
    [SerializeField] float GravityWhenJump;
    [SerializeField] float GravityDefult;
    [Header("Connectable")]
    public TextMeshProUGUI textTimerJump;
    public LayerMask groundCheckLayerMask;




    private bool isJumping = false;
    private bool isGrounded;
    bool FalllingWithSpace;
    private bool isHoldSpace;
    private bool wasJumpExtended = false;
    float MoveY;
    float MoveX;

    private float JumpTimer = 0f;

    public bool GameIsStart;

    Rigidbody2D rb;



    public  void Awake()
    {
       

        GameIsStart = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
        if (GameMenager.Instance.GameBeenStarted())
        {
            CanJump();

        }

    }
    public void CanJump()
    {
        if (isHoldSpace && !isGrounded)
        {
            JumpTimer += Time.deltaTime;
        }

        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(MoveX * moveSpeed, rb.linearVelocity.y);


        HoldSpaceChecker();
        Groundcheck();
        Jump();
        Fallingvalue();





        textTimerJump.text = JumpTimer.ToString();
    }

    private void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;


            rb.linearVelocity += new Vector2(rb.linearVelocity.x, jumpForce);


            

            JumpTimer = 0;
        }

        if (isJumping == true)
        {

            if (isHoldSpace && !wasJumpExtended)
            {




                float progress = Mathf.Clamp01(JumpTimer / MaxjumpTimer);
                //float currentJumpForce = Mathf.Lerp(jumpForce, jumpForceMultiplier, progress);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * jumpForceMultiplier);

                //if (progress >= 1f)
                //{
                //    wasJumpExtended = true;
                //}
            }
            if (isHoldSpace && rb.linearVelocity.y <= 0)
            {
                wasJumpExtended = true;
            }

        }

        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            isJumping = false;
            wasJumpExtended = false;
        }



    }

    private void Groundcheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, groundCheckLayerMask);
    }
    private void Fallingvalue()
    {

        if (rb.linearVelocityY > 0)
        {
            rb.gravityScale = GravityWhenJump;
        }
        else if (isHoldSpace && rb.linearVelocityY < 0)
        {

            rb.gravityScale = GravityFalllingWithSpace;

        }
        else if (rb.linearVelocityY < 0 && !isGrounded)
        {
            rb.gravityScale = GravityFallling;
        }
        else
        {
            rb.gravityScale = GravityDefult;
        }
    }
    private void HoldSpaceChecker()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHoldSpace = true;


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldSpace = false;


        }

    }



}