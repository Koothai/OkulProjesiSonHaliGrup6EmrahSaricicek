using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public LayerMask terrainMask;
    PlayerMovement playermovement;
    public GameObject currentChunk;
    public static float chunkSize = 60f;


    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    public List<Vector3> spawnedChunksPositions;
    GameObject latestChunk;
    public float maxOpDist; // tilemapin genisliginden ve uzunlugundan buyuk olmalidir
    float opDist;
    float optimizerCooldown;
    public float optimizationCooldownDuration;
    List<Vector3> vector3s = new()
    {
       new Vector3(0f, chunkSize, 0f),                         //up
       new Vector3(0f, -chunkSize, 0f),                       //down
       new Vector3(chunkSize, 0f, 0f),                       //right
       new Vector3(-chunkSize, 0f, 0f),                     //left
       new Vector3(chunkSize, chunkSize, 0f),              //upright
       new Vector3(-chunkSize, chunkSize, 0f),            //upleft
       new Vector3(chunkSize, -chunkSize, 0f),           //downright
       new Vector3(-chunkSize, -chunkSize, 0f)          //downleft
        
        
        
    };


   
    void Start()
    {

        playermovement = FindObjectOfType<PlayerMovement>();

    }

    void Update()
    {
        ChunkPositionController();
        ChunkChecker();
        ChunkOptimizer();
    }


    void ChunkChecker()
    {

        if (!currentChunk)
        {
            return;
        }

        if (playermovement.movementDirection.x != 0 || playermovement.movementDirection.y != 0)
        {

            foreach (Vector3 vector in vector3s)
            {

                if (!spawnedChunksPositions.Contains(vector))
                {
                    SpawnChunk(vector);
                    spawnedChunksPositions.Add(vector);
                }
            }
        }
    }


    void SpawnChunk(Vector3 newSpawnPosition)
    {
        int rand = UnityEngine.Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], newSpawnPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);

    }

    void ChunkPositionController()
    {
        if (!currentChunk)
        {
            return;
        }
        vector3s[0] = currentChunk.transform.position + new Vector3(0f, chunkSize, 0f);                         //up
        vector3s[1] = currentChunk.transform.position + new Vector3(0f, -chunkSize, 0f);                       //down
        vector3s[2] = currentChunk.transform.position + new Vector3(chunkSize, 0f, 0f);                       //right
        vector3s[3] = currentChunk.transform.position + new Vector3(-chunkSize, 0f, 0f);                     //left
        vector3s[4] = currentChunk.transform.position + new Vector3(chunkSize, chunkSize, 0f);              //upright
        vector3s[5] = currentChunk.transform.position + new Vector3(-chunkSize, chunkSize, 0f);            //upleft
        vector3s[6] = currentChunk.transform.position + new Vector3(chunkSize, -chunkSize, 0f);           //downright
        vector3s[7] = currentChunk.transform.position + new Vector3(-chunkSize, -chunkSize, 0f);         //downleft                                                                             


    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown < 0f)
        {
            optimizerCooldown = optimizationCooldownDuration;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);

            }
            else
            {
                chunk.SetActive(true);

            }
        }
    }
}
