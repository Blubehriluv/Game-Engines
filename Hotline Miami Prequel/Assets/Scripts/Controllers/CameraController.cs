using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;
    public float turnSpeed = 180;
    [SerializeField] private float distance;
    [SerializeField] private float cameraX, cameraZ;

    void Start()
    {
        
    }

    void Update()
    {
        RotateToMousePointer();
        CameraFollow();
    }

    public void CameraFollow()
    {
        playerCamera.transform.position = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3
            (gameObject.transform.localPosition.x, cameraX, gameObject.transform.localPosition.z), cameraZ);
    }

    private void RotateToMousePointer()
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

        Vector3 relative;
        relative = transform.InverseTransformDirection(Vector3.forward);
        // Debug.Log(relative);
    }

    // Rotates the character towards the mouse cursor.
    private void RotateTowards(Vector3 lookAtPoint)
    {
        // Acquires rotation to be used for looking where we want.
        Quaternion goalRotation = Quaternion.LookRotation(lookAtPoint - transform.position, Vector3.up);

        // Will rotate less than the given TurnSpeed towards the goal.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, turnSpeed * Time.deltaTime * 2);
    }
}
