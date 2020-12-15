using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] int collisionDamage = 2; // TO DO make this based on each meteor size
    private SoundManager soundManager;
    private ShieldAnimation shieldAnimation;
    public ShieldManager shieldManager;
    //public Shields shields;
    //public int playerMaxHitPoints;
    //public float playerCurentHitpoints;
    //public float shieldRestoreValue = 0.010f;
    //public int rescuePoint = 2;


    private void Start()
    {
        shieldAnimation = FindObjectOfType<ShieldAnimation>();
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        shieldManager = FindObjectOfType<ShieldManager>();
        shieldManager.playerCurentHitpoints = shieldManager.playerMaxHitPoints;

        //shields = FindObjectOfType<Shields>();
        //playerCurentHitpoints = playerMaxHitPoints;
        //shields.SetMaxShield(playerCurentHitpoints);
    }

    private void Update()
    {
        // Game over check
        if (shieldManager.playerCurentHitpoints <= -1)
        {
            soundManager.MothershipDestroy();
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
            shieldManager.DecreaseShield(collisionDamage);
            soundManager.MeteorDestroy();
            //shields.SetShield(playerCurentHitpoints);

            if (shieldAnimation.shieldHit == true)
            {
                shieldAnimation.PlayShieldAnimation();
            }

            Destroy(other.gameObject);
        }

        // Player hit points limit reset. To be used with power up
        if (shieldManager.playerCurentHitpoints > shieldManager.playerMaxHitPoints)
        {
            shieldManager.playerCurentHitpoints = shieldManager.playerMaxHitPoints;
        }
    }
}
