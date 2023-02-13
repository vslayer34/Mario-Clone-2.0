using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsGrounded : MonoBehaviour
{
    [SerializeField]
    PlayerController playerControllerScript;

    [SerializeField]
    Animator playerAnimator;

    // Remain grounded on the ground
    private void OnTriggerStay2D(Collider2D collision)
    {
        playerControllerScript.isGrounded = true;


        // disable all jumping and falling animations
        playerAnimator.SetBool(AnimatorParam.playerIsJumping, false);
        playerAnimator.SetBool(AnimatorParam.playerIsFalling, false);
    }


    // set is grounded to false when the player is not colliding on the ground
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerControllerScript.isGrounded = false;
    }
}
