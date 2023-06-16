using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState 
    {
        Gameplay,
        Paused,
        GameOver,
        LevelUp
    }

    public GameState currentState;

    public GameState previousState;

    [Header("Screens")]
    public GameObject pauseScreen;
    public GameObject displayResultsScreen;
    public GameObject levelUpScreen;

    [Header("Current Stats")]
    public Text currentHealthToDisplay;
    public Text currentRecoveryToDisplay;
    public Text currentMoveSpeedToDisplay;
    public Text currentProjectileSpeedToDisplay;
    public Text currentArmorToDisplay;
    public Text currentPierceAddendToDisplay;
    public Text currentDamageMultiplierToDisplay;
    public Text currentAmountAddendToDisplay;
    public Text currentCooldownReductionToDisplay;
    public Text currentAreaMultiplierToDisplay;
    public Text currentCritChanceToDisplay;
    public Text currentMagnetToDisplay;

    [Header("Results Screen")]
    public Image chosenCharacterImage;
    public Text chosenCharacterName;
    public Text levelReachedDisplay;
    public Text timeSurvivedDisplay;
    public List<Image> chosenWeaponsUI = new(6);
    public List<Image> chosenPassiveItemsUI = new(6);

    [Header("Stopwatch")]
    public float timeLimit;
    float stopwatchTime;
    public Text stopwatchDisplay;

    public bool isGameOver =false;

    public bool isLevelUp;

    public GameObject playerObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning($"Fazladan {this} silindi");
        }
        DisableScreens();
    }
    void Update()
    {
        //TestSwitchState();
        switch (currentState)
        {
            case GameState.Gameplay:
                CheckForPauseAndResume();
                UpdateStopWatch();
                break;

            case GameState.Paused:
                CheckForPauseAndResume();
                break;

            case GameState.GameOver:
                if (!isGameOver)
                {
                    isGameOver = true;
                    Time.timeScale = 0f;
                    Debug.Log("Game Over");
                    DisplayResults();
                }
                break;

            case GameState.LevelUp:
                if (!isLevelUp)
                {
                    isLevelUp = true;
                    Time.timeScale = 0f;
                    Debug.Log("Level up oldu abi");
                    levelUpScreen.SetActive(true);
                }
                break;

            default:
                Debug.LogWarning("Bu Oyun State'i Eksik");
                break;
        }
    }
    public void ChangeState(GameState gameState)
    {
        currentState = gameState;
    }

    public void PauseGame()
    {
        if (currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            Debug.Log("Game is Paused");
        }
        
    }

    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            Debug.Log("Game is Paused");
        }
    }

    void CheckForPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void DisableScreens()
    {
        pauseScreen.SetActive(false);
        displayResultsScreen.SetActive(false);
        levelUpScreen.SetActive(false);
    }

    public void GameOver()
    {
        timeSurvivedDisplay.text = stopwatchDisplay.text;
        ChangeState(GameState.GameOver);
    }

    void DisplayResults()
    {
        displayResultsScreen.SetActive(true);
    }

    public void AssignChosenCharacterUI(CharacterScriptableObject chosenCharacterData)
    {
        chosenCharacterImage.sprite = chosenCharacterData.CharacterSprite;
        chosenCharacterName.text = chosenCharacterData.CharacterName;
    }

    public void AssignLevelReachedUI(int levelReachedData)
    {
        levelReachedDisplay.text = levelReachedData.ToString();
    }

    public void AssignChosenWeaponsAndPassiveItems(List<Image> chosenWeaponsData, List<Image> chosenPassiveItemsData)
    {
        if (chosenWeaponsData.Count != chosenWeaponsUI.Count || chosenPassiveItemsData.Count != chosenPassiveItemsUI.Count)
        {
            Debug.Log("Silahlari ve pasif itemleri listelemede hata olustu");
            return;
        }
        for (int i = 0; i < chosenWeaponsUI.Count; i++)
        {
            if (chosenWeaponsData[i].sprite)
            {
                chosenWeaponsUI[i].enabled = true;
                chosenWeaponsUI[i].sprite = chosenWeaponsData[i].sprite;
            }
            else
            {
                chosenWeaponsUI[i].enabled = false;
            }
        }
        for (int i = 0; i < chosenPassiveItemsUI.Count; i++)
        {
            if (chosenPassiveItemsData[i].sprite)
            {
                chosenPassiveItemsUI[i].enabled = true;
                chosenPassiveItemsUI[i].sprite = chosenPassiveItemsData[i].sprite;
            }
            else
            {
                chosenPassiveItemsUI[i].enabled = false;
            }
        }

    }

    void UpdateStopWatch()
    {
        stopwatchTime += Time.deltaTime;
        UpdateStopWatchDisplay();
        if (stopwatchTime >= timeLimit)
        {
            GameOver();
        }
    }

    void UpdateStopWatchDisplay()
    {
        int minutes = Mathf.FloorToInt(stopwatchTime/60);
        int seconds = Mathf.FloorToInt (stopwatchTime%60);

        stopwatchDisplay.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    public void StartLevelUp()
    {
        ChangeState(GameState.LevelUp);
        playerObject.SendMessage("RemoveAndApplyUpgrades");
    }

    public void EndLevelUp()
    {
        isLevelUp = false;
        Time.timeScale = 1f;
        levelUpScreen.SetActive(false);
        ChangeState(GameState.Gameplay);
    }

    //void TestSwitchState()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        currentState++;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        currentState--;
    //    }
    //}
}
