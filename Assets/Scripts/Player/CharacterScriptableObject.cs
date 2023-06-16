using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField]
    string characterName; //karakter goruntusu
    public string CharacterName { get => characterName; private set => characterName = value; }


    [SerializeField]
    Sprite characterSprite; //karakter goruntusu
    public Sprite CharacterSprite { get => characterSprite; private set => characterSprite = value; }

    [SerializeField]
    AnimatorController characterAnimator; //karakter goruntusu
    public AnimatorController CharacterAnimator { get => characterAnimator; private set => characterAnimator = value; }


    // burasi weapon list olacak 6 tane weapon alacak baslangic weaponu karakter secim ekraninda (CharacterSelector.cs) atanacak digerleri ise level atladikca gelenlerden olacak
    //burasi da passive skill list baslangic skilli yok
    [SerializeField]                   
    GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField]
    float maxHealth; //max can
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField]
    float recovery;  // saniyede yenilenen can miktari
    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField]
    float moveSpeed; //hareket hizi
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    float armor;    //zirh
    public float Armor { get => armor; private set => armor = value; }

    [SerializeField]
    int pierceAddend; //pierce ekleme
    public int PierceAddend { get => pierceAddend; private set => pierceAddend = value; }

    [SerializeField]
    float damageMultiplier; //hasar carpani
    public float DamageMultiplier { get => damageMultiplier; private set => damageMultiplier = value; }

    [SerializeField]
    float amountAddend; // adet ekleme
    public float AmountAddend { get => amountAddend; private set => amountAddend = value; }

    [SerializeField]
    float cooldownReduction; // bekleme suresinde azalma
    public float CooldownReduction { get => cooldownReduction; private set => cooldownReduction = value; }

    [SerializeField]
    float areaMultiplier; // alan carpani
    public float AreaMultiplier { get => areaMultiplier; private set => areaMultiplier = value; }

    [SerializeField]
    float critChance; // kritik vurma ihtimali
    public float CritChance { get => critChance; private set => critChance = value; }

    [SerializeField]
    float projectileSpeedMultiplier; // Atilan esyalarin hizini arttirma
    public float ProjectileSpeedMultiplier { get => projectileSpeedMultiplier; private set => projectileSpeedMultiplier = value; }

    [SerializeField]
    float magnet; // drop toplama alani genisligi
    public float Magnet { get => magnet; private set => magnet = value; }

}
