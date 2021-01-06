using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShieldManager : MonoBehaviour
{
    private SoundManager soundManager;
    private GameManager gameManager;
    private Scene activeScene;
    private string sceneName;
    public float playerHitpoints;
    public int playerMaxHitPoints;
    public int gameOverInt = -1;
    public Text shieldText;

    // Start is called before the first frame update
    void Start()
    {
        // Set shield defaults and references
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        gameManager = FindObjectOfType<GameManager>();
        shieldText = GameObject.Find("ShieldText").GetComponent<Text>();
        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;
        LevelModeCheck();
    }

    private void Update()
    {
        // Game over check
        if (playerHitpoints <= gameOverInt)
        {
            soundManager.MothershipDestroy();
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    // ADD shield value and update text
    public void IncreaseShield(int increaseShield)
    {
        playerHitpoints += increaseShield;
        UpdateShieldText();

        // Player hit points limit reset
        if (playerHitpoints > playerMaxHitPoints)
        {
            playerHitpoints = playerMaxHitPoints;
        }
    }

    // SUBTRACT shield value and update text
    public void DecreaseShield(int decreaseShield)
    {
        playerHitpoints -= decreaseShield;
        UpdateShieldText();
    }

    // Update shield text method
    public void UpdateShieldText()
    {
        shieldText.text = $"Shields: {playerHitpoints}%";
    }

    // Save hit points to global player variables
    public void SavePlayerData()
    {
        GlobalPlayerVariables.Instance.playerCurrentHitpoints = playerHitpoints;
    }

    // Check if playing first level to set initial hitpoints
    private void LevelModeCheck()
    {
        if (sceneName == "Level_01")
        {
            playerHitpoints = playerMaxHitPoints;
        }
        else
        {
            playerHitpoints = GlobalPlayerVariables.Instance.playerCurrentHitpoints;
            UpdateShieldText();
        }
    }
}
