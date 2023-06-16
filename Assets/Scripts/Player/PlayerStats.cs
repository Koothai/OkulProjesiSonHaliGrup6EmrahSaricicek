using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    CharacterScriptableObject characterData;

       // baslangic statlari
     float currentHealth;
     float currentRecovery;
     float currentMoveSpeed;
     float currentProjectileSpeed;
     float currentArmor;
     float currentPierceAddend;
     float currentDamageMultiplier;
     float currentAmountAddend;
     float currentCooldownReduction;
     float currentAreaMultiplier;
     float currentCritChance;
     float currentMagnet;
    


    #region UpdateProperties

    public float CurrentHealth
    {
        get { return currentHealth; }
        set 
        {
            if (currentHealth != value)
            {
                currentHealth = value;
                if (GameManager.instance !=null)
                {
                    GameManager.instance.currentHealthToDisplay.text = $"Health: {currentHealth}";
                }
            }
        }
    }

    public float CurrentRecovery
    {
        get { return currentRecovery; }
        set 
        {
            if (currentRecovery != value)
            {
                currentRecovery = value;
                if (GameManager.instance != null)
                {

                    GameManager.instance.currentRecoveryToDisplay.text = $"Recovery: {currentRecovery}";
                }
            }
        }
    }

    public float CurrentMoveSpeed
    {
        get { return currentMoveSpeed; }
        set
        {
            if (currentMoveSpeed != value)
            {
                currentMoveSpeed = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentMoveSpeedToDisplay.text = $"Movement Speed: {currentMoveSpeed}";
                }
                Debug.Log("Hiz Degeri Degisti");
            }
        }
    }
    public float CurrentProjectileSpeed
    {
        get { return currentProjectileSpeed; }
        set
        {
            if (currentProjectileSpeed != value)
            {
                currentProjectileSpeed = value;
                if (GameManager.instance != null)
                {

                    GameManager.instance.currentProjectileSpeedToDisplay.text = $"Projectile Speed: {currentProjectileSpeed}";
                }
                Debug.Log("Hiz Degeri Degisti");
            }
        }
    }

     public float CurrentArmor
    {
        get { return currentArmor; }
        set 
        {
            if (currentArmor != value)
            {
                currentArmor = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentArmorToDisplay.text = $"Armor: {currentArmor}";
                }
            }
        }
    }
    
    public float CurrentPierceAddend
    {
        get { return currentPierceAddend; }
        set 
        {
            if (currentPierceAddend != value)
            {
                currentPierceAddend = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentPierceAddendToDisplay.text = $"Pierce: {currentPierceAddend}";
                }
            }
        }
    } 
    
    public float CurrentDamageMultiplier
    {
        get { return currentDamageMultiplier; }
        set 
        {
            if (currentDamageMultiplier != value)
            {
                currentDamageMultiplier = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentDamageMultiplierToDisplay.text = $"Damage Multiplier: {currentDamageMultiplier}";
                }
            }
        }
    } 
    
    public float CurrentAmountAddend
    {
        get { return currentAmountAddend; }
        set 
        {
            if (currentAmountAddend != value)
            {
                currentAmountAddend = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentAmountAddendToDisplay.text = $"Amount: {currentAmountAddend}";
                }
            }
        }
    } 
    
    public float CurrentCooldownReduction
    {
        get { return currentCooldownReduction; }
        set 
        {
            if (currentCooldownReduction != value)
            {
                currentCooldownReduction = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentCooldownReductionToDisplay.text = $"Cooldown Reduction: {currentCooldownReduction}";
                }
            }
        }
    }
    
    public float CurrentAreaMultiplier
    {
        get { return currentAreaMultiplier; }
        set 
        {
            if (currentAreaMultiplier != value)
            {
                currentAreaMultiplier = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentAreaMultiplierToDisplay.text = $"Area: {currentAreaMultiplier}";
                }
            }
        }
    }
    
    public float CurrentCritChance
    {
        get { return currentCritChance; }
        set 
        {
            if (currentCritChance != value)
            {
                currentCritChance = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentCritChanceToDisplay.text = $"Chance: {currentCritChance}";
                }
            }
        }
    }
    
    public float CurrentMagnet
    {
        get { return currentMagnet; }
        set 
        {
            if (currentMagnet != value)
            {
                currentMagnet = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentMagnetToDisplay.text = $"Magnet: {currentMagnet}";
                }
            }
        }
    }
    #endregion

    // sprite ve animasyon
    public Animator currentAnimator;
    public SpriteRenderer currentCharacterSpriteRenderer;

    #region LevelStats
    // deneyim ve seviye statlari

    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;


    // deneyim ve seviye ayari
    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }



    public List<LevelRange> levelRanges;

    InventoryManager inventoryManager;
    public int weaponIndex;
    public int passiveItemIndex;



    #endregion
    [Header("UI")]
    public Image healthBar;
    public Image expBar;
    public Text levelText;

    public GameObject fpitemtest;
    public GameObject fpitemtest2;
    public GameObject weapontest;



    void Awake()
    {
        currentCharacterSpriteRenderer = GetComponent<SpriteRenderer>();
        currentAnimator = GetComponent<Animator>();
        //datayi statlardan once cagir yoksa null reference veriyor
        // player statlarini character selector classindaki datalardan cekiyoruz
        characterData = CharacterSelector.GetData();



        AnimatorController.SetAnimatorController(currentAnimator, characterData.CharacterAnimator);

        currentCharacterSpriteRenderer.sprite = characterData.CharacterSprite;

        // playerin statlari player objesine gectigi icin selectorde yarattigimiz instance i yok ediyoruz
        CharacterSelector.instance.DestroySingleton();





        inventoryManager = GetComponent<InventoryManager>();

        // guncel statlar
        CurrentMoveSpeed = characterData.MoveSpeed;
        CurrentProjectileSpeed = characterData.ProjectileSpeedMultiplier;
        CurrentHealth = characterData.MaxHealth;
        CurrentRecovery = characterData.Recovery;
        CurrentArmor = characterData.Armor;
        CurrentPierceAddend = characterData.PierceAddend;
        CurrentDamageMultiplier = characterData.DamageMultiplier;
        CurrentAmountAddend = characterData.AmountAddend;
        CurrentCooldownReduction = characterData.CooldownReduction;
        CurrentAreaMultiplier = characterData.AreaMultiplier;
        CurrentCritChance = characterData.CritChance;
        CurrentMagnet = characterData.Magnet;

        // spawn fonksiyonu
        //SetSpriteAndAnimator(characterData.CharacterSprite);
        SpawnWeapon(characterData.StartingWeapon);
        //SpawnWeapon(weapontest);
        //SpawnPassiveItem(fpitemtest);
        //SpawnPassiveItem(fpitemtest2);
    }

    void Start()
    {
        // deneyim sinirini  baslat
        experienceCap = levelRanges[0].experienceCapIncrease;

        // Ekrana stat yazdirmak
        GameManager.instance.currentHealthToDisplay.text = $"Health: {currentHealth}";
        GameManager.instance.currentRecoveryToDisplay.text = $"Recovery: {currentRecovery}";
        GameManager.instance.currentMoveSpeedToDisplay.text = $"Movement Speed: {currentMoveSpeed}";
        GameManager.instance.currentProjectileSpeedToDisplay.text = $"Projectile Speed: {currentProjectileSpeed}";
        GameManager.instance.currentArmorToDisplay.text = $"Armor: {currentArmor}";
        GameManager.instance.currentPierceAddendToDisplay.text = $"Pierce: {currentPierceAddend}";
        GameManager.instance.currentDamageMultiplierToDisplay.text = $"Damage Multiplier: {currentDamageMultiplier}";
        GameManager.instance.currentAmountAddendToDisplay.text = $"Amount: {currentAmountAddend}";
        GameManager.instance.currentCooldownReductionToDisplay.text = $"Cooldown Reduction: {currentCooldownReduction}";
        GameManager.instance.currentAreaMultiplierToDisplay.text = $"Area: {currentAreaMultiplier}";
        GameManager.instance.currentCritChanceToDisplay.text = $"Chance: {currentCritChance}";
        GameManager.instance.currentMagnetToDisplay.text = $"Magnet: {currentMagnet}";

        GameManager.instance.AssignChosenCharacterUI(characterData);

        UpdateHealthBar();
        UpdateExpBar();
        UpdateLevelText();
    }
    void Update()
    {
        Recover();
    }
    public void IncreaseExperience(int Amount)
    {
        experience += Amount;
        LevelUpChecker();
        UpdateExpBar();
    }


    void LevelUpChecker()    // Fazla gelen tecrubenin sonraki levele aktarilabilmesi icin kod
    {
        if (experience >= experienceCap)
        {
            // seviyeyi arttir ve tecrube puanini duzelt

            level++;
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;

            UpdateLevelText();
            GameManager.instance.StartLevelUp();

        }
    }

    void UpdateExpBar()
    {
        expBar.fillAmount = (float)experience / experienceCap;
    }
    void UpdateLevelText()
    {
        levelText.text = $"Level: {level}";
    }

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= (dmg);

        if (CurrentHealth <= 0)
        {
            Kill();
        }
        UpdateHealthBar();
    }
    public void RestoreHealth(float amount)
    {
        if (CurrentHealth < characterData.MaxHealth)
        {
            CurrentHealth += amount;
            if (CurrentHealth>characterData.MaxHealth)
            {
                CurrentHealth = characterData.MaxHealth;
            }

        }
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / characterData.MaxHealth;
    }

    public void Kill()
    {
        if (!GameManager.instance.isGameOver)
        {
            GameManager.instance.AssignLevelReachedUI(level);
            GameManager.instance.AssignChosenWeaponsAndPassiveItems(inventoryManager.weaponUISlots, inventoryManager.passiveItemUISlots);
            GameManager.instance.GameOver();
        }
    }

    void Recover()
    {
        if (CurrentHealth < characterData.MaxHealth)
        {
            CurrentHealth += CurrentRecovery * Time.deltaTime;

            if (CurrentHealth > characterData.MaxHealth)
            {
                CurrentHealth = characterData.MaxHealth;
            }
        }
    }

    public void SpawnWeapon(GameObject weapon)
    {

        if (weaponIndex >= inventoryManager.weaponSlots.Count - 1)
        {
            Debug.LogError("waaa weapon indexi duzeltmen lazim");
            return;
        }
        //baslangic silahini yarat
        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        // playerin childi yap
        spawnedWeapon.transform.SetParent(transform);
        // olusturulmus silahlar listesine ekle
        inventoryManager.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponController>());
        weaponIndex++;
    }

    public void SpawnPassiveItem(GameObject passiveItem)
    {

        if (passiveItemIndex >= inventoryManager.passiveItemSlots.Count - 1)
        {
            Debug.LogError("waaa passiveitem indexi duzeltmen lazim");
            return;
        }

        GameObject spawnedPassiveItem = Instantiate(passiveItem, transform.position, Quaternion.identity);
        // playerin childi yap
        spawnedPassiveItem.transform.SetParent(transform);
        // olusturulmus pasifler listesine ekle
        inventoryManager.AddPassiveItem(passiveItemIndex, spawnedPassiveItem.GetComponent<PassiveItem>());
        passiveItemIndex++;
    }







}
