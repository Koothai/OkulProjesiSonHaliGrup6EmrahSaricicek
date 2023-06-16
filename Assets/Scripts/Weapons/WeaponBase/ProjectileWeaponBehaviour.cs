using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Butun firlatilabilir objeler icin temel kod

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;
    public PlayerStats playerStats;



    // baslangic statlari

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;
    protected int currentProjectileAmount;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
        currentProjectileAmount = weaponData.Amount;
        
    }

   public float GetCurrentDamage()
    {
        return currentDamage *= FindObjectOfType<PlayerStats>().CurrentDamageMultiplier;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        float directionx = direction.x;
        float directiony = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (directionx < 0 && directiony == 0)  //left
        {
            scale.x *= -1;
        }
        else if (directionx == 0 && directiony < 0) //down
        {
            rotation.z = 270;
        }
        else if (directionx == 0 && directiony > 0) //up
        {
            rotation.z = 90;
        }
        else if (directionx > 0 && directiony > 0) //right up
        {
            rotation.z = 45;
        }
        else if (directionx > 0 && directiony < 0) //right down
        {
            rotation.z = 315;
        }
        else if (directionx < 0 && directiony > 0) //left up
        {
            rotation.z = 135;
        }
        else if (directionx < 0 && directiony < 0) //left down
        {
            rotation.z = 225;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }

    // collider degdiginde canavar hasar alir
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            EnemyStats enemy = collider.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);   
            ReducePierce();
        }
        else if (collider.CompareTag("Prop"))
        {
            if (collider.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(GetCurrentDamage());
            }
        }
      
    }

    void ReducePierce() // delici ozelligilin sayisini 0 a dogru goturuyor
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }


}
