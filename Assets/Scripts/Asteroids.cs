using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    private Vector3 playerLastPosition;
    private Rigidbody enemyProjectileRigidBody;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the game objects rigid bodies to apply movement
        enemyProjectileRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        // This condition needs to be set up only at start, otherwise, if
        // it's set in update, the game object will continue to track the player every frame
        if (player != null)
        {
            // Regular projectile
            playerLastPosition = (player.transform.position - transform.position).normalized * projectileSpeed;
            enemyProjectileRigidBody.velocity = new Vector3(playerLastPosition.x, playerLastPosition.y);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerProjectile_Lv01")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

