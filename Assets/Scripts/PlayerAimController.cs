using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimController : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] Camera cam;
    Vector2 mousePosition;

    // Update is called once per frame
    void Update()
    {
        // Convert mouse position from pixel coordinates to world units
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDirection = mousePosition - rigidbody.position;
        float aimAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = aimAngle;
    }
}
