using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollisions : MonoBehaviour
{
    private ShieldAnimation shieldAnimation;
    private int playershield = 3;

    // Start is called before the first frame update
    void Start()
    {
        shieldAnimation = FindObjectOfType<ShieldAnimation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect collisions on shields and flash shield
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Hazard")
        {
            Debug.Log("Collision!");
            playershield -= 1;
            Debug.Log("Shield:"+ playershield);

            shieldAnimation.shieldHit = true;

            if (shieldAnimation.shieldHit == true)
            {
                shieldAnimation.PlayShieldAnimation();
            }

            Destroy(other.gameObject);
        }
    }
}
