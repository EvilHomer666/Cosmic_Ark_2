using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] ShieldManager shieldManager;
    [SerializeField] int collisionDamage = 5; // TO DO make this based on each meteor size
    private ShieldAnimation shieldAnimation;
    private SoundManager soundManager;

    private void Start()
    {
        shieldAnimation = FindObjectOfType<ShieldAnimation>();
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        shieldManager = FindObjectOfType<ShieldManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect collisions on shields and flash shield
        if (other.gameObject.tag == "Hazard")
        {
            shieldAnimation.shieldHit = true;
            shieldManager.DecreaseShield(collisionDamage);
            soundManager.MeteorDestroy();

            if (shieldAnimation.shieldHit == true)
            {
                shieldAnimation.PlayShieldAnimation();
            }

            // Game over check
            if (shieldManager.playerHitpoints <= 0)
            {
                soundManager.MothershipDestroy();
            }

            Destroy(other.gameObject);
        }
    }
}
