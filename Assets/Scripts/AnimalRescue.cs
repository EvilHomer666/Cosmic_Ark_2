using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRescue : MonoBehaviour
{
    private DetectPlayerCollisions playerRescueBonus;
    private ScoreManager scoreManager;
    private Shields shields;

    private void Start()
    {
        playerRescueBonus = FindObjectOfType<DetectPlayerCollisions>();
        scoreManager = FindObjectOfType<ScoreManager>();
        shields = FindObjectOfType<Shields>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Detect when animal reaches the UFO
        if (other.gameObject.tag == "Creature")
        {
            Destroy(other.gameObject);
            playerRescueBonus.playerCurentHitpoints += playerRescueBonus.rescuePoint;
            shields.SetShield(playerRescueBonus.playerCurentHitpoints);
            scoreManager.score += scoreManager.rescueBonus;

        }
    }
}
