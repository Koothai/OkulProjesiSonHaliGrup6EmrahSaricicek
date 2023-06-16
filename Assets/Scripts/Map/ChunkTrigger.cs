using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController controller;
    public GameObject targetMap;
    void Start()
    {
        controller = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))     //Eger targetmapin bulundugu alan playere degiyorsa targetMap currentChunk dir
        {
            controller.currentChunk = targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))       //player o alandan ciktiginda 
        {
            if (controller.currentChunk == targetMap)   // o alan targetmap ise o alani artik bosver
            {
                controller.currentChunk = null;
            }
        }
    }
}
