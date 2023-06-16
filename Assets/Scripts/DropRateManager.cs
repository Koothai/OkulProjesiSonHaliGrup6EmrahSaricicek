using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    // Toplanabilir esyalari duzenleyen kod

    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;

    }

    public List<Drops> drops;

    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            return;  //oyunu durdurunca karakterler teorik olarak destroylandigi icin ekranda xp gem kaliyor. Ondestroy erroru almamak icin eger oyun loaded degilse return atiyoruz
        }

        float rndm = UnityEngine.Random.Range(0f, 100f);
        List<Drops> possibleDrops = new() ;

        foreach (Drops rate in drops) 
        {
            if (rndm <= rate.dropRate)
            {
                possibleDrops.Add(rate);
            }
        }

        //birden fazla drop var mi diye bakma 

        if (possibleDrops.Count>0)
        {
            Drops drops = possibleDrops[UnityEngine.Random.Range(0,possibleDrops.Count)];
            Instantiate(drops.itemPrefab, transform.position, Quaternion.identity);
        }
    }

}
