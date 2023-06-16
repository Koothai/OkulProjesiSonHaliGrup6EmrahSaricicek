using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponScribtableObject",menuName ="ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    // skillerin ve silahlarin temel statlari
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    [SerializeField]
    float damage;// Silahin verecegi hasar
    public float Damage { get => damage; private set=> damage = value; }

    [SerializeField]
    float speed; // silahin gidis hizi
    public float Speed { get => speed; private set => speed = value; }
    
    [SerializeField]
    int amount; // silahin gidis hizi
    public int Amount { get => amount; private set => amount = value; }

    [SerializeField]
    float cooldownDuration; //bekleme suresi 
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }

    [SerializeField]
    int pierce; //kac dusmana vurduktan sonra yok olacagi
    public int Pierce { get => pierce; private set => pierce = value; }

    [SerializeField]
    int level; //oyun icinde degistirilmemesi gerekiyor
    public int Level { get => level; private set => level = value; }

    [SerializeField]
    GameObject nextLevelPrefab; //sonraki levelin prefabi(obje level atlayinca olacak hali) (sonraki levelde olusacak olan prefab degil)
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }

    [SerializeField]
    string weaponName;
    public string WeaponName { get => weaponName; private set => weaponName = value; }

    [SerializeField]
    string description;
    public string Description { get => description; private set => description = value; }

    [SerializeField]
    Sprite icon;
    public Sprite Icon { get => icon; private set => icon = value; }
}






