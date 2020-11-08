using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectPlayerCollisions : MonoBehaviour
{
    public Shields shields;
    [SerializeField] GameManager gameManager;
    [SerializeField] int collisionDamage = 1;
    private ShieldAnimation shieldAnimation;    
    public int playerMaxHitPoints;
    public float playerCurentHitpoints;

    private void Start()
    {
        shieldAnimation = FindObjectOfType<ShieldAnimation>();
        shields = FindObjectOfType<Shields>();
        playerCurentHitpoints = playerMaxHitPoints;
        shields.SetMaxShield(playerCurentHitpoints);
    }

    private void Update()
    {
        // Game over check
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
            shieldAnimation.shieldHit = true;
            playerCurentHitpoints -= collisionDamage;
            shields.SetShield(playerCurentHitpoints);

            if (shieldAnimation.shieldHit == true)
            {
                shieldAnimation.PlayShieldAnimation();
            }

            Destroy(other.gameObject);
        }

        // Player hit points limit reset. To be used with power up
        if (playerCurentHitpoints > playerMaxHitPoints)
        {
            playerCurentHitpoints = playerMaxHitPoints;
        }
    }
}
