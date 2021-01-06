using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] int shieldBonus;
    [SerializeField] int scoreBonus;
    private ScoreManager scoreManager;
    private ShieldManager shieldManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        shieldManager = FindObjectOfType<ShieldManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect when animal reaches the UFO
        if (other.gameObject.tag == "UFO")
        {
            shieldManager.IncreaseShield(shieldBonus);
            scoreManager.IncrementScore(scoreBonus);
            Destroy(gameObject);
        }
    }
}
