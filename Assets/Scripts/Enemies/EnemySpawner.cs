using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{



    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; // mevcut dalga icinde dogacak olan dusman gruplarinin listesi
        public int waveSize;  //  mevcut dalga icinde olan dogacak dusmanlarin sayisi
        public float spawnInterval;  // dogacaklari aralik
        public int spawnCount; // mevcut dalga icinde dogmus olan dusmanlarin sayisi
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount; // mevcut dalgadaki dusman sayisi
        public int spawnCount; // mevcut dalgadaki dogmus dusman sayisi
        public GameObject enemyPrefab;
    }

    public List<Wave> waves;  // butun dalgalarin sayisi
    public int currentWaveCount;  //mevcut dalgalarin indeksi

    [Header("Spawner Attributes")]
    float spawnTimer; // dusmanlari ne kadar sure aralikla spawnlayacagimiz
    public int enemiesAlive; // yasayan dusmanlar
    public int maxEnemiesAllowed; // dusman sayisi siniri
    public bool isMaxEnemiesReached = false; // trigger mekanizmasi
    public float waveInterval; // dalgalar arasindaki interval


    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPoints; // dusmanlarin dogacaklari yerler


    public static float spawnPointVector = 30f;


    Transform player;
    public Vector3 currentSpawnPointCheck;


    public List<Vector3> vector3List = new()
    {
       new Vector3(0f, spawnPointVector, 0f),                         //up
       new Vector3(0f, -spawnPointVector, 0f),                       //down
       new Vector3(spawnPointVector, 0f, 0f),                       //right
       new Vector3(-spawnPointVector, 0f, 0f),                     //left
       new Vector3(spawnPointVector, spawnPointVector, 0f),              //upright
       new Vector3(-spawnPointVector, spawnPointVector, 0f),            //upleft
       new Vector3(spawnPointVector, -spawnPointVector, 0f),           //downright
       new Vector3(-spawnPointVector, -spawnPointVector, 0f)          //downleft     
    };


   

    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveSize();

    }

    void Update()
    {
        // mevcut dalga bittiyse sonrakine gec
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);
        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveSize();
        }
    }

    void CalculateWaveSize()
    {
        int currentWaveSize = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveSize += enemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveSize = currentWaveSize;
        Debug.LogWarning(currentWaveSize);
    }

    void SpawnEnemies()
    {

        // dogacak dusman sayisi dogmasi gerekenden az ise
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveSize && !isMaxEnemiesReached)
        {

            // her dusman turu icin 
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        isMaxEnemiesReached = true;
                        return;
                    }

                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[UnityEngine.Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);
                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;

                }
            }

        }
        if (enemiesAlive < maxEnemiesAllowed)
        {
            isMaxEnemiesReached = false;
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }

   

}
