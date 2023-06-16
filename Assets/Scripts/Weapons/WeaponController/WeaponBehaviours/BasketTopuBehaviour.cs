using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTopuBehaviour : ProjectileWeaponBehaviour
{

    protected override void Start()
    {
        base.Start();

    }

    void Update()
    {
        transform.position += Time.deltaTime * weaponData.Speed * direction;  //gidis hizi
    }
}

    

