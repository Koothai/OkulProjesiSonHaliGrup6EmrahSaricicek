using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GarlicBehaviour : MeleeWeaponBehaviour
{

    protected override void Start()
    {
        base.Start();
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            float damagePerTick = GetCurrentDamage() * Time.fixedDeltaTime / 2;

            EnemyStats enemy = collision.GetComponent<EnemyStats>();

            enemy.TakeDamage(damagePerTick);


        }
        else if (collision.CompareTag("Prop"))
        {
            if (collision.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(GetCurrentDamage());
            }
        }
    }

    

}
