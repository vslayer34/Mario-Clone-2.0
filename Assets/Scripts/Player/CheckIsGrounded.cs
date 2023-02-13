using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsGrounded : MonoBehaviour
{
    [SerializeField]
    PlayerController playerControllerScript;

    // Remain grounded on the ground
    private void OnTriggerStay2D(Collider2D collision)
    {
        playerControllerScript.isGrounded = true;
    }


    // set is grounded to false when the player is not colliding on the ground
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerControllerScript.isGrounded = false;
    }
}
