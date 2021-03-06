using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed, jumpForce;
    private Vector2 moveInput;
    public LayerMask isGround;
    public Transform groundPoint;
    private bool isGrounded;


    private bool movingRight;
    private bool movingLeft;
    private bool idling;
    private bool movingUp;
    private bool movingDown;
    public Animator anim;

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
        if(moveInput.x > 0)
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }

        if(moveInput.x < 0)
        {
            movingLeft = true;
        }
        else
        {
            movingLeft = false;
        }

        //vertical movement

        if (moveInput.y < 0)
        {
            movingDown = true;
        }
        else
        {
            movingDown = false;
        }

        if (moveInput.y > 0)
        {
            movingUp = true;
        }
        else
        {
            movingUp = false;
        }


        anim.SetBool("movingRight", movingRight);
        anim.SetBool("movingLeft", movingLeft);
        anim.SetBool("movingDown", movingDown);
        anim.SetBool("movingUp", movingUp);

        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, isGround))
        {
            isGrounded = true;
            
        }
        else
        {
            isGrounded = false;
            
        }

        if(Input.GetButtonDown("Jump") && isGrounded &&!SingleLevel.isPaused)
        {
            rb.velocity += new Vector3(0f, jumpForce, 0f);
        }
        anim.SetBool("onGround", isGrounded);
    }
}
