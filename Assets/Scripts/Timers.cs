using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timers : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float roundTime; // Inital level time at 60 sec. This number will change depending on game progression.
    [SerializeField] GameObject scoreManager;
    private LevelTransition levelTransition;
    

    // Start is called before the first frame update
    void Start()
    {
        levelTransition = FindObjectOfType<LevelTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        GamePlayMode();
    }

    // Methods to control timing between levels
    private void GamePlayMode()
    {
        // Level Timer
        roundTime -= Time.deltaTime;
        timerText.text = $"Time: {roundTime.ToString("n2")}";
        if (score <= roundTime)
        {
            levelTransition.MoveToNextLevel();
        }
    }
}
