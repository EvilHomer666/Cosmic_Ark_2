﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracktorBeam : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    // Applies an upwards force to all rigidbodies that enter the trigger.
    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.AddForce(Vector3.up * 10);
    }
}
