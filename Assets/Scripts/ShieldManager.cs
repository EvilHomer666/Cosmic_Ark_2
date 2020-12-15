using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] Text shieldText;

    // Singleton used to carry shield values across scenes
    public static ShieldManager Instance { get; private set; }
    public int playerMaxHitPoints;
    public float playerCurentHitpoints;
    public int rescuePoint = 2;

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
        // Set shield defaults and references
        playerCurentHitpoints = playerMaxHitPoints;
        UpdateShieldText();
    }

    // Add shield value and update text
    public void IncreaseShield(int increaseShield)
    {
        playerCurentHitpoints += increaseShield;
        UpdateShieldText();
    }
    // Substract shield value and update text
    public void DecreaseShield(int decreaseShield)
    {
        playerCurentHitpoints -= decreaseShield;
        UpdateShieldText();
    }

    // Update shield text method
    public void UpdateShieldText()
    {
        shieldText.text = $"Shields: {playerCurentHitpoints}%";
    }
}
