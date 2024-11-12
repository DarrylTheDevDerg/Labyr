using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Hold : MonoBehaviour
{
    [Header("Grab Settings")]
    public float grabDistance = 5.0f; // How far the Player can reach to grab an object
    public float holdDistance = 1.5f; // How far the grabbed object should be from the Player's camera
    public float grabSmoothness = 10.0f; // How smooth the object moves towards the hold position
    public LayerMask grabbableLayer; // Layer for objects that can be grabbed

    private Transform playerCamera; // Reference to the Player's camera
    private Transform grabbedObject = null; // The currently grabbed object

    private Rigidbody grabbedObjectRb; // Rigidbody of the grabbed object

    void Start()
    {
        // Find the Player's camera (assumes this script is attached to the Player)
        playerCamera = Camera.main.transform;
    }

    void Update()
    {
        // If the Player presses "E", try grabbing or releasing an object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedObject == null)
            {
                TryGrabObject();
            }
            else
            {
                ReleaseObject();
            }
        }

        // Move the object with the Player’s camera if it's currently held
        if (grabbedObject != null)
        {
            MoveObjectWithCamera();
        }
    }

    void TryGrabObject()
    {
        // Raycast forward from the camera to detect grabbable objects
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, grabDistance, grabbableLayer))
        {
            // If we hit an object on the specified layer, grab it
            grabbedObject = hit.transform;
            grabbedObjectRb = grabbedObject.GetComponent<Rigidbody>();

            if (grabbedObjectRb != null)
            {
                // Disable physics temporarily
                grabbedObjectRb.isKinematic = true;
            }
        }
    }

    void ReleaseObject()
    {
        if (grabbedObjectRb != null)
        {
            // Re-enable physics when releasing
            grabbedObjectRb.isKinematic = false;
            grabbedObjectRb = null;
        }

        grabbedObject = null;
    }

    void MoveObjectWithCamera()
    {
        // Target position in front of the camera at holdDistance
        Vector3 targetPosition = playerCamera.position + playerCamera.forward * holdDistance;

        // Smoothly move the object to the target position
        grabbedObject.position = Vector3.Lerp(grabbedObject.position, targetPosition, Time.deltaTime * grabSmoothness);
    }
}
