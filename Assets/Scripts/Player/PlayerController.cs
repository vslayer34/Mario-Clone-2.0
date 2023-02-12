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

    float movementX;                                        // variable to save the joystick horizantal movement

    void Start()
    {
        // get a referance to the player rigid body
        playerRB = GetComponent<Rigidbody2D>();
        
        // set the player speed to value in the player stats
        speed = playerStats.speed;
    }

    void Update()
    {
        // update the values of joysticj horziontal movement
        movementX = joystick.Horizontal;
    }

    void FixedUpdate()
    {
        Move(movementX);
    }

    /// <summary>
    /// get the input of the joystick and moves the player rigidbody accordingly
    /// flip the sprite renderer to the corret direction
    /// </summary>
    /// <param name="input"></param>
    void Move(float input)
    {
        if (input == 0)
            playerRB.velocity = new Vector2(0.0f, playerRB.velocity.y);           // instant stop

        // flip the sprite renderer
        else if (input < 0)
            playerSprite.flipX = true;
        else
            playerSprite.flipX = false;

        // move the player
        playerRB.velocity = new Vector2(input * Time.deltaTime * speed, playerRB.velocity.y);
        playerAnimator.SetFloat(AnimatorParam.playerSpeed, Mathf.Abs(input));
    }
}
