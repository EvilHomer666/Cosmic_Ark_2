using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffect : MonoBehaviour
{
    [SerializeField] int rotationSpeed = 10;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0 * Time.deltaTime);
    }
}
