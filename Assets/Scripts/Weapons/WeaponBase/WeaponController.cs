using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    float currentCooldown; // guncel bekleme suresi


    protected PlayerMovement playerMovement;
    public float spread = 0.5f;


    protected virtual void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        currentCooldown = weaponData.CooldownDuration;                               // karakter silahi aldiginda direkt aktif olmamasi icin bekleme suresine sokuyoruz. buraya                                                                                 cooldown duration multiplierler eklenicek
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;                                   // bekleme suresi biter bitmez silah aktif oluyor
        if (currentCooldown <=0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }
}
