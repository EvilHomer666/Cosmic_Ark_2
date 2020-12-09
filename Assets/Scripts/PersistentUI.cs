using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentUI : MonoBehaviour
{
    // Singleton used to carry persistent UI across scenes
    public static PersistentUI Instance { get; private set; }

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
}
