using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class er_mov : MonoBehaviour
{
    public float playerSpeed;
    public float playerJumpSpeed;
    protected int direction;
    Rigidbody2D rb2d;
    Animator anim;

    private bool moveLeft, moveRight, isJumpes;

    void Start()
    {
        direction = 0;
        moveLeft = false;
        moveRight = false;
        isJumpes = false;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (direction != 0) transform.eulerAngles = direction < 0 ? new Vector2(0,180) : new Vector2(0,0);
    }

    protected void FixedUpdate() 
    {
        if (moveRight)
        {
            rb2d.velocity = new Vector2(playerSpeed * Time.fixedDeltaTime, rb2d.velocity.y );
            
        }
        if (moveLeft)
        {
            rb2d.velocity = new Vector2(-playerSpeed * Time.fixedDeltaTime, rb2d.velocity.y );
            
        }

        if(rb2d.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
        }
        if(rb2d.velocity.x == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
        }
        else {
        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false); 
        }
    }

    public void PlayerMoveRight()
    {
        moveRight = true;
        direction = 1;
    }

    public void PlayerMoveLeft()
    {
        moveLeft = true;
        direction = -1;
    }

    public void PlayerJumping()
    {
        if(rb2d.velocity.y == 0)
            {
                rb2d.AddForce( Vector2.up * playerJumpSpeed, ForceMode2D.Impulse);
            }
    }

    public void PlayerStopMove()
    {
        moveRight = false;
        moveLeft = false;
    }
}
