using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] int scoreValue = 250;
    [SerializeField] int shieldRestoreValue = 2;
    private SoundManager soundManager;
    private ScoreManager scoreManager;
    private ShieldManager shieldManager;

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
        }
    }
}
