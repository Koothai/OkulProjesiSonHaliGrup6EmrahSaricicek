using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// butun yakinci silahlar icin temel kod (yakinci silahin prefabine koyulacak)
public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    public float destroyAfterSeconds;
    private PlayerStats playerStats;



    // baslangic statlari 
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

     void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        currentDamage = weaponData.Damage * playerStats.CurrentDamageMultiplier;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }
    public float GetCurrentDamage()
    {
        return currentDamage *= FindObjectOfType<PlayerStats>().CurrentDamageMultiplier;
    }


    protected virtual void Start()
    {
        Destroy(gameObject,destroyAfterSeconds);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            EnemyStats enemy = collider.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage());   //BURAYA currentDamage + zirh delme - armor gelecek
        }
        else if (collider.CompareTag("Prop"))
        {
            if (collider.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(GetCurrentDamage());
            }
        }
    }

  


}
