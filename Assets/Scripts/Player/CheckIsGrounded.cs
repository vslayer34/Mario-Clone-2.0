using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsGrounded : MonoBehaviour
{
    [SerializeField]
    PlayerController playerControllerScript;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        playerControllerScript.isGrounded = true;
    }
}
