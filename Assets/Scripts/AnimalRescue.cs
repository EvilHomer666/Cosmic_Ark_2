using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRescue : MonoBehaviour
{
    private DetectPlayerCollisions playerRescueBonus;
    private int rescuePoint = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Detect when animal reaches the UFO
        if (other.gameObject.tag == "Creature")
        {
            playerRescueBonus.playerCurentHitpoints += rescuePoint;
            Destroy(other.gameObject);
        }
    }
}
