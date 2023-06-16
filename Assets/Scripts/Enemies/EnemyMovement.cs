using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    EnemyStats enemy;
    SpriteRenderer spriteRenderer;

    Transform player;
    public float movDirX;
    public float movDirY;
    public float movDirCompareX;
    public float movDirCompareY;
    public float movDirFarkX; 
    public float movDirFarkY; 


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemy = GetComponent<EnemyStats>();

        player = FindObjectOfType<PlayerMovement>().transform;

    }


    void Update()
    {
         
        SpriteDirectionChecker();

    }

    void SpriteDirectionChecker()
    {
        movDirX = transform.position.x;
        movDirY = transform.position.y;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);     //dusman sana yuruyor

        movDirCompareX = transform.position.x;
        movDirCompareY = transform.position.y;
        movDirFarkX = movDirCompareX - movDirX;
        movDirFarkY = movDirCompareY - movDirY;

        if (movDirFarkX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
