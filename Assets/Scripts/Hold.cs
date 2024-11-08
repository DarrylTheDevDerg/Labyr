using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
    public KeyCode key;
    public string objectTag;

    public Transform cameraTransform; // Main camera's transform to cast the ray from
    public float maxRayDistance = 5f; // Maximum distance for raycast detection
    public LayerMask holdableLayer;   // Layer mask to filter out non-holdable objects
    private Transform heldObject;     // The object currently held
    private Vector3 holdOffset = new Vector3(0, 0, 2); // Offset for positioning in front of camera

    private void Update()
    {
        if (heldObject != null)
        {
            FollowCamera();
        }

        if (Input.GetKeyDown(key))
        {
            CheckForObject();
        }

        // Drop the object if the player presses a key (e.g., "E")
        if (Input.GetKeyDown(key) && heldObject != null)
        {
            DropObject();
        }
    }

    private void CheckForObject()
    {
        // Cast a ray from the camera forward
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, holdableLayer))
        {
            // Check if the object hit is tagged as "Holdable" and there’s no held object
            if (hit.transform.CompareTag(objectTag) && heldObject == null && Input.GetKeyDown(KeyCode.E))
            {
                PickUpObject(hit.transform);
            }
        }
    }

    private void FollowCamera()
    {
        // Position the held object in front of the camera, following its rotation
        heldObject.position = cameraTransform.position + cameraTransform.forward * holdOffset.z;
        heldObject.rotation = Quaternion.LookRotation(cameraTransform.forward);
    }

    private void PickUpObject(Transform obj)
    {
        heldObject = obj;
        heldObject.SetParent(cameraTransform); // Parent it to the camera for automatic movement
    }

    private void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.SetParent(null); // Unparent to release it
            heldObject = null;
        }
    }
}
