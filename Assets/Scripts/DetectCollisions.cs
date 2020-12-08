using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //[SerializeField] float hitPoints = 1; // TO DO: Use this if making stronger hazards
    [SerializeField] int scoreValue = 250;
    private ScoreManager scoreManager;
    private DetectPlayerCollisions restoreShield;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        restoreShield = FindObjectOfType<DetectPlayerCollisions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile_Lv01")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            scoreManager.IncrementScore(scoreValue); // Add score

            // Add shield restore points and update UI
            restoreShield.playerCurentHitpoints += restoreShield.shieldRestoreValue;
            restoreShield.shields.SetShield(restoreShield.playerCurentHitpoints);
        }
    }
}
