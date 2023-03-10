using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();
        // handle drag
        if(grounded)
        {
            rb.drag = groundDrag;
            airMultiplier = 0.05f;
        }
        else 
        {
            rb.drag = 0;
            airMultiplier = 0.1f; 
        }
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        if(Input.GetKey(jumpKey) && readyToJump && IsGrounded())
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    /*
        if(Input.GetKey(jumpKey) && readyToJump && grounded){
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
      }
      */
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
         rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

         rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
         jumpSound.Play();
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }


    private void ResetJump()
    {
        readyToJump = true;
    }

     private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy Head"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(50);
            Jump();
        }
    }
    
}
