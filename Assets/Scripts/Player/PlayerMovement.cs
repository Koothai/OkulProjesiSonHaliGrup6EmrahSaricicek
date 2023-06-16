using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Hareket

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 movementDirection;
    [HideInInspector]
    public Vector2 lastMovementVector;


    //referanslar
    Rigidbody2D rb;
    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        lastMovementVector = new Vector2(1, 0f); // oyun basladiginda hareket etmezsek diye son gidilen yeri sag taraf yapiyoruz
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    void InputManagement()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(moveX, moveY).normalized;

        if (movementDirection.x !=0)
        {
            lastHorizontalVector = movementDirection.x;
            lastMovementVector = new Vector2(lastHorizontalVector, 0f); // yatay gidilen son yer
        }
        if (movementDirection.y !=0)
        {
            lastVerticalVector = movementDirection.y;
            lastMovementVector = new Vector2(0f, lastVerticalVector); // dikey gidilen son yer

        }
        if (movementDirection.x != 0 && movementDirection.y != 0)
        {
            lastMovementVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        rb.velocity = new Vector2(movementDirection.x * playerStats.CurrentMoveSpeed, movementDirection.y * playerStats.CurrentMoveSpeed);
    }
}
