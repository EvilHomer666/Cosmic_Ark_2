using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] Shields shields;
    [SerializeField] GameManager gameManager;
    [SerializeField] int collisionDamage = 1;
    private ShieldAnimation shieldAnimation;    
    public int playerMaxHitPoints;
    public int playerCurentHitpoints;

    private void Start()
    {
        shieldAnimation = FindObjectOfType<ShieldAnimation>();
        shields.SetMaxShield(playerCurentHitpoints);
        playerCurentHitpoints = playerMaxHitPoints;
    }

    private void Update()
    {
        // Player game over check
        if (playerCurentHitpoints <= -1)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect collisions on shields and flash shield
        if (other.gameObject.tag == "Hazard")
        {
            Debug.Log("Collision!");
            Debug.Log("Shield:" + playerCurentHitpoints);

            shieldAnimation.shieldHit = true;
            playerCurentHitpoints -= collisionDamage;
            shields.SetShield(playerCurentHitpoints);

            if (shieldAnimation.shieldHit == true)
            {
                shieldAnimation.PlayShieldAnimation();
            }

            Destroy(other.gameObject);
        }

        // Player hit points limit reset
        if (playerCurentHitpoints > playerMaxHitPoints)
        {
            playerCurentHitpoints = playerMaxHitPoints;
        }
    }
}
