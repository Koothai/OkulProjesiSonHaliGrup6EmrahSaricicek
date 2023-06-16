using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    Transform player;
    PlayerStats stats;
    CircleCollider2D playerCollector;
    public float pullSpeed;  // toplanabilir esyalarin gelme hizi

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;

        stats = FindObjectOfType<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
        
    }
    void Update()
    {
        playerCollector.radius *= stats.CurrentMagnet;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // gemleri bize dogru getiren kod

        //eger colliderin degdigi obje icollectable objesi ise onu collectle
        if (collision.gameObject.TryGetComponent(out ICollectable collectable))
        {
            //esyayi ilerletiyor
            collision.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, pullSpeed*Time.deltaTime);
            // esyayi topluyor
            collectable.Collect();
        }
    }
}
