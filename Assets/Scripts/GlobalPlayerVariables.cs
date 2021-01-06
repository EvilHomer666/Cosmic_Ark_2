using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayerVariables : MonoBehaviour
{
    public static GlobalPlayerVariables Instance;
    // Global variables to be called and updated by scoreManager and shieldManager
    public float playerCurrentHitpoints;
    public int playerCurrentScore;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
