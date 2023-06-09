using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float jumpForce;
   public float speed;
   private Rigidbody2D rb;
   

   public Transform groundPos;
   private bool isGrounded;
   public float checkRadius;
   public LayerMask whatIsGround;

   private float jumpTimeCounter;
   public float jumpTime;
   private bool isJumping;
   private bool doubleJump;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
      isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

      if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
      {
        anim.SetTrigger("takeOf");
        
        rb.velocity = Vector2.up * jumpForce;
        isJumping = true;
        jumpTimeCounter = jumpTime;
      } 
        if (isGrounded is true)
        {
            doubleJump = false;
            anim.SetBool("isJumping", false);
        }
        else 
        {
            anim.SetBool("isJumping", true);
            
        }

        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else 
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false ;
        }

        if (isGrounded == false && doubleJump == false && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            doubleJump = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        Debug.Log("moveInput");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
             anim.SetBool("isRunning", true);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}
