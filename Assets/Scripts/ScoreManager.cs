using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    private int score;
    private Scene activeScene;
    private string sceneName;
    public int rescueBonus = 400;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Set score defaults and references
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;
        InitialScoreCheck();
        UpdateScoreText();
    }

    // Add score value and update text
    public void IncrementScore(int updatedScore)
    {
        score += updatedScore;
        UpdateScoreText();
    }

    // Update score text method
    public void UpdateScoreText()
    {
        scoreText.text = $"SCORE: {score}";
    }

    // Save hit points to global player variables
    public void SavePlayerData()
    {
        GlobalPlayerVariables.Instance.playerCurrentScore = score;
    }

    // Check if playing first level to set initial score
    private void InitialScoreCheck()
    {
        if (sceneName == "Level_01")
        {
            score = 0;
        }
        else
        {
            score = GlobalPlayerVariables.Instance.playerCurrentScore;
            UpdateScoreText();
        }
    }
}
