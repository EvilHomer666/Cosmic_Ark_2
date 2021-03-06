﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private int levelToLoad;

    // Methods to pass level index
    private void LoadNextLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
    }

    // Method to load next scene
    public void MoveToNextLevel()
    {
        LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(levelToLoad);
    }

    // Method to load next scene during demo
    public void RecycleLevel()
    {
        SceneManager.LoadScene("Level_01");
    }
}
