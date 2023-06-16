using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTopuController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnBasketball = Instantiate(weaponData.Prefab);

        spawnBasketball.transform.position = transform.position; // bicagin cikacagi yeri player yaptik
        spawnBasketball.GetComponent<BasketTopuBehaviour>().DirectionChecker(playerMovement.lastMovementVector.normalized); // yon belirleme

    }
}
