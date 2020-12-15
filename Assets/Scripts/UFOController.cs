using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    [SerializeField] AudioClip ufoMovement;
    [SerializeField] float playerSpeed;
    private TracktorBeamActivation tracktorBeam;
    private AudioSource audioSource;
    private float xRange = 85f;
    private float yRangeUp = 5f;
    private float yRangeDown = 50f;
    private float horizontalInput;
    private float verticalInput;
    public bool isEnabled; // Variable to check for UFO movement condition


    private void Start()
    {
        tracktorBeam = FindObjectOfType<TracktorBeamActivation>();
        audioSource = GetComponent<AudioSource>();
        isEnabled = true;
    }

    void Update()
    {
        // Check for horizontal & vertical player movement boundary
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -yRangeDown)
        {
            transform.position = new Vector3(transform.position.x, -yRangeDown, transform.position.z);
        }
        if (transform.position.y > yRangeUp)
        {
            transform.position = new Vector3(transform.position.x, yRangeUp, transform.position.z);
        }           
    }

    void FixedUpdate()
    {
        if (isEnabled == true)
        {
            // Player input movement
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed, Space.World);

            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * verticalInput * Time.deltaTime * playerSpeed, Space.World);

        }

        // UFO movement SFX condition
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
                if (!audioSource.isPlaying)
            {
                audioSource.clip = ufoMovement;
                audioSource.Play();
            }
        }
        else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            if (audioSource.isPlaying)
            {
                audioSource.clip = ufoMovement;
                audioSource.Stop();
            }
        }
        else if (Input.GetKey(KeyCode.Mouse0) && Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (audioSource.isPlaying)
            {
                audioSource.clip = ufoMovement;
                audioSource.Stop();
            }
        }
    }
}
