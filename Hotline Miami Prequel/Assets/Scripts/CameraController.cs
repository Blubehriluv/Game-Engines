using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;
    public float turnSpeed = 180;
    [SerializeField] private float distance;

    void Start()
    {
        
    }

    void Update()
    {
        RotateToMousePointer();
    }

    public void RotateToMousePointer()
    {
        // Acquire the plane
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        // A ray is cast from the mouse to the plane.
        Ray theRay = playerCamera.ScreenPointToRay((Input.mousePosition));
        // This gives us the actual distance
        groundPlane.Raycast(theRay, out distance);
        // Use the given distance to find the point.
        Vector3 targetPoint = theRay.GetPoint(distance);

        // Calls the RotateTowards function
        RotateTowards(targetPoint);
    }

    // Rotates the character towards the mouse cursor.
    public void RotateTowards(Vector3 lookAtPoint)
    {
        // Acquires rotation to be used for looking where we want.
        Quaternion goalRotation = Quaternion.LookRotation(lookAtPoint - transform.position, Vector3.up);

        // Will rotate less than the given TurnSpeed towards the goal.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, turnSpeed * Time.deltaTime);
    }
}
