using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // TO DO: Refactor this entire script for better performance

    // SFX clips
    [SerializeField] AudioClip UFO_Movement;
    [SerializeField] AudioClip FireProjectile;
    [SerializeField] AudioClip UFO_Scaning;
    [SerializeField] AudioClip UFO_Rescuing;
    [SerializeField] AudioClip MeteorDestroyed;
    [SerializeField] AudioClip MothershipDestroyed;


    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Player SFX
    public void UFO_Move()
    {
        audioSource.PlayOneShot(UFO_Movement, 1.0f);
        return;
    }
    public void Fire()
    {
        audioSource.PlayOneShot(FireProjectile, 0.5f);
        return;
    }
    public void UFO_Scan()
    {
        audioSource.PlayOneShot(UFO_Scaning, 1.0f);
        return;
    }
    public void UFO_Rescue()
    {
        audioSource.PlayOneShot(UFO_Rescuing, 1.0f);
        return;
    }
    public void MeteorDestroy()
    {
        audioSource.PlayOneShot(MeteorDestroyed, 1.5f);
        return;
    }
    public void MothershipDestroy()
    {
        audioSource.PlayOneShot(MothershipDestroyed, 1.0f);
        return;
    }
}
