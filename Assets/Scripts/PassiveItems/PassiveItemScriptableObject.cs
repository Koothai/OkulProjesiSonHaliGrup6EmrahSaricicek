using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PassiveItemScriptableObject",menuName ="ScriptableObjects/PassiveItem")]
public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField]
    float multiplier; //hareket hizi
    public float Multiplier { get => multiplier; private set => multiplier = value; }

    [SerializeField]
    int level; //oyun icinde degistirilmemesi gerekiyor
    public int Level { get => level; private set => level = value; }

    [SerializeField]
    GameObject nextLevelPrefab; //sonraki levelin prefabi(obje level atlayinca olacak hali) (sonraki levelde olusacak olan prefab degil)
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }

    [SerializeField]
    string passiveItemName;
    public string PassiveItemName { get => passiveItemName; private set => passiveItemName = value; }

    [SerializeField]
    string description;
    public string Description { get => description; private set => description = value; }

    [SerializeField]
    Sprite icon;
    public Sprite Icon { get => icon; private set => icon = value; }

}
