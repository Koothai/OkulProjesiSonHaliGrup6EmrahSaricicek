using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public EnemyScriptableObject enemyData;
    public PlayerStats playerStats;


    Animator animator;
    BoxCollider2D boxCollider;
    //AnimatorControllerParameter param;
    //EnemyMovement enemyMovement;


    



    // baslangic statlari
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentDamage;

    public float despawnDistance = 50f;

    Transform player;


    readonly float t = 1f; // kac saniye sonra yok olacagi ( olme animasyonu eklemek icin koydum)


    void Awake() //starttan daha once basladigi icin awake kullandik
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        //param = GetComponent<AnimatorControllerParameter>();
        //enemyMovement = GetComponent<EnemyMovement>();
        //playerStats = gameObject.GetComponent<PlayerStats>();


        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position,player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Kill() 
    {
        animator.SetTrigger("Death");  // olme animasyonunu burda oynatiyorum
        Destroy(boxCollider);
        Destroy(gameObject,t);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage*Time.fixedDeltaTime);
            //KnockBackEffect(0.5f);
   
            
        }
        
    }

    private void OnDestroy()
    {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.OnEnemyKilled();
    }

    void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();

        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }

}
