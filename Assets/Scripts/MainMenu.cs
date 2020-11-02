using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject playerAvatar;

    private void Start()
    {
        //playerAvatar = FindObjectOfType<GameObject>();
    }

    // Custom methods to show credits, main menu, start & quit game
    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        playerAvatar.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        playerAvatar.SetActive(true);
        credits.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
