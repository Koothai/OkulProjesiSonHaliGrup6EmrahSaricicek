using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        for (int i = 0; i < weaponData.Amount; i++)
        {
            GameObject spawnedKnife = Instantiate(weaponData.Prefab);
            Vector3 newPosition = transform.position;
            if (weaponData.Amount > 1)
            {
                newPosition.y -= (spread * (weaponData.Amount-1) ) / 2;
                newPosition.y += i * spread;
            }
            


            spawnedKnife.transform.position = newPosition; // firlatilacagi yeri player yaptik
            spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(playerMovement.lastMovementVector);   //yon icin referans

        }
        base.Attack();
        
    }
}