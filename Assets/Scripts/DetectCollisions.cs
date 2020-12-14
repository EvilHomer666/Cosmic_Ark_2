using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //[SerializeField] float hitPoints = 1; // TO DO: Use this if making stronger hazards
    [SerializeField] int scoreValue = 250;
    private SoundManager soundManager;
    private ScoreManager scoreManager;
    private DetectPlayerCollisions restoreShield;

    // Start is called before the first frame update
    void Start()
    {
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        restoreShield = FindObjectOfType<DetectPlayerCollisions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile_Lv01")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            soundManager.MeteorDestroy();
            scoreManager.IncrementScore(scoreValue); // Add score

            // Add shield restore points and update UI
            restoreShield.playerCurentHitpoints += restoreShield.shieldRestoreValue;
            restoreShield.shields.SetShield(restoreShield.playerCurentHitpoints);
        }
    }
}
