using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRescue : MonoBehaviour
{
    [SerializeField] int creatureRescueBonus; // TO DO makes based on the type of creature - special creatures
    private ScoreManager scoreManager;
    public ShieldManager shieldManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        shieldManager = FindObjectOfType<ShieldManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Detect when animal reaches the UFO
        if (other.gameObject.tag == "Creature")
        {
            Destroy(other.gameObject);
            shieldManager.IncreaseShield(creatureRescueBonus);
            scoreManager.score += scoreManager.rescueBonus;

        }
    }
}
