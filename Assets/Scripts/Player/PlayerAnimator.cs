using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //Referanslar

    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;


    void Start()
    {
        animator= GetComponent<Animator>();   
        playerMovement= GetComponent<PlayerMovement>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerMovement.movementDirection.x != 0 || playerMovement.movementDirection.y != 0)
        {
            animator.SetBool("Move", true);         
        }
        else
        {
            animator.SetBool("Move", false);
        }

        SpriteDirectionChecker();
    }

    void SpriteDirectionChecker()
    {
        if (playerMovement.lastHorizontalVector <0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
