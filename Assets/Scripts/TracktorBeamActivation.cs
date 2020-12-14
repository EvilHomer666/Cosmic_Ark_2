using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracktorBeamActivation : MonoBehaviour
{
    [SerializeField] GameObject tracktorBeam;
    private UFOController ufoController;

    void Start()
    {
        // References
        ufoController = FindObjectOfType<UFOController>();
        tracktorBeam.SetActive(false);
    }

    void Update()
    {
        // Tracktor beam activation
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ufoController.isEnabled = false;
            tracktorBeam.SetActive(true);
        }
        else
        {
            ufoController.isEnabled = true;
            tracktorBeam.SetActive(false);
        }
    }
}
