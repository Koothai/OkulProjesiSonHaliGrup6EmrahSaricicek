using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZincirController : WeaponController
{
    SpriteRenderer spriteRenderer;
    protected override void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject whip = Instantiate(weaponData.Prefab);
        whip.transform.parent = transform;

        if (playerMovement.lastHorizontalVector > 0) 
        {
            whip.transform.position = transform.position + new Vector3(2f, 0, 0);
        }
        else 
        {
            spriteRenderer.flipX = true;
            whip.transform.position = transform.position + new Vector3(-2f, 0, 0);
        }
           

        //for (int i = 0; i < weaponData.Amount; i++)
        //{
        //    if (weaponData.Amount == 1)
        //    {
        //    }
        //}
    }
}


   


