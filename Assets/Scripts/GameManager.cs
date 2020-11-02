using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text gameOverText;
    [SerializeField] Text tryAgainText;
    private float pauseDelay = 1;
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
        tryAgainText.text = "Press 'R' Key to Try Again or Esc to Quit";
        StartCoroutine(PauseTime());
    }

    // Coroutine method to allow player SFX to finish before pausing for game over screen.
    IEnumerator PauseTime()
    {
        yield return new WaitForSeconds(pauseDelay);
        gameOver = true;
        Debug.Log("Game Over!");
        Time.timeScale = 0; // << Pauses game
    }


    // Used to quit game before main menu was added <<< >>> NEEDS TO BE MOVED TO MAIN MENU option
    //    public void QuitGame()
    //    {
    //#if UNITY_EDITOR
    //        UnityEditor.EditorApplication.isPlaying = false;
    //#else
    //        Application.Quit();
    //#endif
    //    }

}




