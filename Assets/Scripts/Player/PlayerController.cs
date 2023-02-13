using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Stats playerStats;
    Rigidbody2D playerRB;                                   // rigid body variabe
    [SerializeField]
    SpriteRenderer playerSprite;                            // reference to the sprite renderer
    [SerializeField]
    Joystick joystick;                                      // reference to the joystick
    [SerializeField]
    Animator playerAnimator;

    // variables to save the joystick input movement
    float movementX;
    float movementY;

    public bool isGrounded;

    public UnityEvent jump;

    void Start()
    {
        // get a referance to the player rigid body
        playerRB = GetComponent<Rigidbody2D>();
        
        
    }

    void Update()
    {
        // update the values of joystick movement
        movementX = joystick.Horizontal;
        movementY = joystick.Vertical;
    }

    void FixedUpdate()
    {
        Move(movementX);
        //Jump(isGrounded);
    }

    /// <summary>
    /// get the input of the joystick and moves the player rigidbody accordingly
    /// flip the sprite renderer to the corret direction
    /// </summary>
    /// <param name="inputX"></param>
    void Move(float inputX)
    {
        if (inputX == 0)
            playerRB.velocity = new Vector2(0.0f, playerRB.velocity.y);           // instant stop

        // flip the sprite renderer
        else if (inputX < 0)
            playerSprite.flipX = true;
        else
            playerSprite.flipX = false;

        // move the player
        playerRB.velocity = new Vector2(inputX * Time.deltaTime * playerStats.speed, playerRB.velocity.y);
        playerAnimator.SetFloat(AnimatorParam.playerSpeed, Mathf.Abs(inputX));
    }


    public void Jump(bool isGrounded)
    {
        if (movementY > 0.5 && isGrounded)
        {
            Vector2 jumpDirection = Vector2.up * playerStats.jumpForce * Time.deltaTime;
            playerRB.AddForce(jumpDirection, ForceMode2D.Impulse);
        }
    }
}
