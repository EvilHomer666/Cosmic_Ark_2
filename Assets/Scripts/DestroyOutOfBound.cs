using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{ 
    // Custom method to destroy any other object that hits the pay boundary that is not the player.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
