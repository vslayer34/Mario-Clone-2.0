using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    float speed;                                            // speed of the player
    float jumpForce;

    // variables to save the joystick input movement
    float movementX;
    float movementY;

    void Start()
    {
        // get a referance to the player rigid body
        playerRB = GetComponent<Rigidbody2D>();
        
        
    }

    void Update()
    {
        // set the player speed to value in the player stats
        speed = playerStats.speed;
        jumpForce = playerStats.jumpForce;

        // update the values of joystick movement
        movementX = joystick.Horizontal;
        movementY = joystick.Vertical;
    }

    void FixedUpdate()
    {
        Move(movementX);
        Jump(movementY);
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
        playerRB.velocity = new Vector2(inputX * Time.deltaTime * speed, playerRB.velocity.y);
        playerAnimator.SetFloat(AnimatorParam.playerSpeed, Mathf.Abs(inputX));
    }


    void Jump(float inputY)
    {
        if (inputY > 0.5)
        {
            Vector2 jumpDirection = Vector2.up * jumpForce * Time.deltaTime;
            playerRB.AddForce(jumpDirection, ForceMode2D.Impulse);
        }
    }
}
