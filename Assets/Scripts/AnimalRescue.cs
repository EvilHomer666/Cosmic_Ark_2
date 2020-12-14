using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRescue : MonoBehaviour
{
    private DetectPlayerCollisions playerRescueBonus;
    private int recuePoint = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Detect when animal reaches the ship
        if (other.gameObject.tag == "Creature")
        {
            playerRescueBonus.playerCurentHitpoints += recuePoint;
            Destroy(other.gameObject);
        }
    }
}
