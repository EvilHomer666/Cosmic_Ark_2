﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timers : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float roundTime; // Start level time at 60 sec. This number will change depending on game progression.
    private ShieldManager shieldData;
    private ScoreManager scoreData;
    private LevelTransition sceneManager;
    private float timerLimit = 0.005f;
    

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<LevelTransition>();
        shieldData = FindObjectOfType<ShieldManager>();
        scoreData = FindObjectOfType<ScoreManager>();
        // TO DO add condition to check score and adjust round time based on game progress.
    }

    // Update is called once per frame
    void Update()
    {
        GamePlayMode();
    }

    // Methods to control timing between levels.
    private void GamePlayMode()
    {
        // Level Timer.
        roundTime -= Time.deltaTime;
        timerText.text = $"TIME: {roundTime.ToString("n2")}";

        if (roundTime < timerLimit)
        {
            shieldData.SavePlayerData();
            scoreData.SavePlayerData();
            sceneManager.MoveToNextLevel();
        }
    }
}
