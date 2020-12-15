using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;

    // Singleton used to carry score across scenes
    public static ScoreManager Instance { get; private set; }
    public int rescueBonus = 400;
    public int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set score defaults and references
        score = 0;
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
}
