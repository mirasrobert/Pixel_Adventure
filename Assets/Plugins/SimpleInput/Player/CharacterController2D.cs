using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;

    private float horizontalInput = 0f;
    private bool IS_GROUNDED = true;

    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpForce = 5f;
     
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheckLeft;
    [SerializeField] Transform groundCheckRight;

    // Add Audio
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        // Check if player is on ground or not
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Foreground")) ||
            Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Foreground")) ||
            Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Foreground")))
        {
            IS_GROUNDED = true;
        }
        else
        {
            IS_GROUNDED = false;
        }

        //horizontalInput = Input.GetAxisRaw("Horizontal"); // Player Controller [A & D Keyboard]
        horizontalInput = SimpleInput.GetAxisRaw("Horizontal"); // For Mobile
        rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y); // Player Move

        FlipPlayer();
 
        // If Player is Moving then play animation
        if (horizontalInput == 1 || horizontalInput == -1)
        {
            animator.SetBool("running", true);
        } else
        {
            animator.SetBool("running", false);
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y); 
        }

        if (Input.GetKey("space") && IS_GROUNDED) // Jump if Space bar is Pressed and Player is on Ground
        {
            JumpMovement();
        }
       
    }

    // For Mobile
    public void JumpMovement()
    {

        if (IS_GROUNDED)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            animator.SetTrigger("jumping");
            jumpSoundEffect.Play();
        }

    }

    public void FlipPlayer()
    {
        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


}
