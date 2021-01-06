using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text gameOverText;
    [SerializeField] Text tryAgainText;
    private float pauseDelay = 2;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Set UI defaults
        gameOver = false;
        gameOverText.text = "";
        tryAgainText.text = "";
    }

    void Update()
    {
        // Condition to continue
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }

            // Condition to quit game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
                Time.timeScale = 1;
                // SceneManager.LoadScene(SceneManager.GetSceneByName("HighScores")); TO DO << load scores screen after game over and quit
            }
        }
    }

    public void GameOver()
    {
        // Game Over condition            
        gameOverText.text = "Game Over";
        tryAgainText.text = "PRESS R KEY TO TRY AGAIN     ESC TO QUIT";
        StartCoroutine(PauseTime());
    }

    // Coroutine to pause on game over
    IEnumerator PauseTime()
    {
        yield return new WaitForSeconds(pauseDelay);
        gameOver = true;
        Time.timeScale = 0;
    }
}




