using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public playerController controller;
    public float dashCountDown;
    public float runSpeed = 40f;
    public float maxVelocity;
    float horizontalMove = 0f;
    bool jump = false;
    bool isJumping;
    float jumpTimeCounter;
    public float jumpTime;
    //For determining which way the player is currently facing
    private bool facingRight;
    Rigidbody2D rb;
    Vector2 vel;
    Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private float m_JumpForce = 400f;
    Animator animator;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("dead")) {
            Jump();
        }
    }


    void FixedUpdate(){
        if(!animator.GetBool("dead")){
            //Disable the fucking box collider and rigidbody you stupid fuck
            vel = rb.velocity;
            Move(horizontalMove * Time.fixedDeltaTime, jump);
            jump = false;

            //Limit the fallspeed
            if (vel.magnitude > maxVelocity) {
                rb.velocity = vel.normalized * maxVelocity;
            }

            Pause();
        }
    }

    public void Move(float move, bool jump) {
        //Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);

        //And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        //if input is moving the player right and the player is facing left
        if (move > 0 && facingRight)
            Flip();

        else if (move < 0 && !facingRight)
            Flip();
        //*******************************************************
    }

    private void Flip() {
        facingRight = !facingRight;

        //multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Jump() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump") && controller.m_Grounded) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * m_JumpForce;
        }
        if (Input.GetButton("Jump") && isJumping) {
            if (jumpTimeCounter > 0) {
                rb.velocity = Vector2.up * m_JumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump") && isJumping) {
            isJumping = false;
            rb.velocity = Vector2.up * m_JumpForce;
        }
    }

    private void Pause() {
        if (Input.GetButtonDown("Cancel")) {
            SceneTransition.Transition("PauseMenu", LoadSceneMode.Additive);
        }
    }
}
