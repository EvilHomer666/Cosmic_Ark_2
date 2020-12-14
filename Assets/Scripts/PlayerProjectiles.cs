using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    [SerializeField] Transform aimCannon;
    [SerializeField] GameObject playerProjectileLv_01;
    [SerializeField] float speedForce = 20f;
    private SoundManager soundManager;

    private void Start()
    {
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            soundManager.Fire();
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        GameObject playerProjectile = Instantiate(playerProjectileLv_01, aimCannon.position, aimCannon.rotation);
        Rigidbody rigidBody = playerProjectile.GetComponent<Rigidbody>();
        rigidBody.AddForce(aimCannon.up * speedForce, ForceMode.Impulse);
    }
}
