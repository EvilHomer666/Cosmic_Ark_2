using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //[SerializeField] float hitPoints = 1; // TO DO: Use this if making stronger hazards
    [SerializeField] int scoreValue = 250;
    [SerializeField] int shieldRestoreValue = 1;
    //[SerializeField] int damageValue = 2; // Damage value to the player
    private SoundManager soundManager;
    private ScoreManager scoreManager;
    //private DetectPlayerCollisions restoreShield;
    private ShieldManager shieldManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        shieldManager = FindObjectOfType<ShieldManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile_Lv01")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            soundManager.MeteorDestroy();
            scoreManager.IncrementScore(scoreValue); // Add score
            shieldManager.IncreaseShield(shieldRestoreValue); // Restore shield to player

            // Add shield restore points and update UI
            //shieldManager.playerCurentHitpoints += shieldManager.shieldRestoreValue;
            //shieldManager.shields.SetShield(restoreShield.playerCurentHitpoints);
        }
    }
}
