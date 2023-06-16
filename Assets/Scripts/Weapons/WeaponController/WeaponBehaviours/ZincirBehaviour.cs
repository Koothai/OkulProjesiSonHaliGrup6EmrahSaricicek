using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZincirBehaviour : MeleeWeaponBehaviour
{
   
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
        }
    }

 
}
