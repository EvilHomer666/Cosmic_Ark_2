using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracktorBeamActivation : MonoBehaviour
{
    [SerializeField] GameObject tracktorBeam;
    private UFOController ufoController;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to UFO controller script
        ufoController = FindObjectOfType<UFOController>();
        tracktorBeam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Tracktor beam activation
        if (Input.GetKey(KeyCode.Mouse0))
        {
            tracktorBeam.SetActive(true);
            ufoController.enabled = false;

        }
        else
        tracktorBeam.SetActive(false);
        ufoController.enabled = true;
    }
}
