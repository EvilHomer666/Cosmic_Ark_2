using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] Shields shields;
    [SerializeField] int collisionDamage = 1;
    private ShieldAnimation shieldAnimation;    
    public int playerMaxHitPoints;
    public int playerCurentHitpoints;

    // Start is called before the first frame update
    void Start()
    {
        shieldAnimation = FindObjectOfType<ShieldAnimation>();
        shields.SetMaxShield(playerCurentHitpoints);
        playerCurentHitpoints = playerMaxHitPoints;
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
    }
}
