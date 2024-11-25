using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventPassThroughWalls : MonoBehaviour
{
    public LayerMask obstacleLayer;       // Layers considered "solid walls"
    public float radius = 0.5f;           // Radius of the object's "collision zone"
    public float collisionOffset = 0.1f; // Distance to stop before the wall
    public string solidTag;

    public BoxCollider[] boundaryColliders; // Array of Box Colliders defining boundaries

    private Transform holder;             // The current holder (e.g., player or camera)
    private float holdDistance;           // How far the object is held

    void Awake()
    {
        // Find all Box Colliders with the specified tag in the scene
        GameObject[] boundaryObjects = GameObject.FindGameObjectsWithTag(solidTag);
        boundaryColliders = new BoxCollider[boundaryObjects.Length];

        for (int i = 0; i < boundaryObjects.Length; i++)
        {
            boundaryColliders[i] = boundaryObjects[i].GetComponent<BoxCollider>();
        }
    }

    public void StartHolding(Transform holder, float holdDistance)
    {
        this.holder = holder;
        this.holdDistance = holdDistance;
    }

    public void StopHolding()
    {
        this.holder = null;
    }

    void FixedUpdate()
    {
        if (holder == null) return;

        // Calculate the target position
        Vector3 targetPosition = holder.position + holder.forward * holdDistance;

        // Perform a sphere cast to check for obstacles
        RaycastHit hit;
        if (Physics.SphereCast(holder.position, radius, holder.forward, out hit, holdDistance, obstacleLayer))
        {
            // If an obstacle is detected, adjust the target position
            float safeDistance = hit.distance - collisionOffset;
            targetPosition = holder.position + holder.forward * Mathf.Max(safeDistance, 0);
        }

        // Ensure the target position stays within the closest boundary
        if (boundaryColliders != null && boundaryColliders.Length > 0)
        {
            targetPosition = EnforceBoundaries(targetPosition);
        }

        // Move the object to the corrected target position
        transform.position = targetPosition;
    }

    Vector3 EnforceBoundaries(Vector3 position)
    {
        Vector3 finalPosition = position;
        float closestDistance = float.MaxValue;

        foreach (BoxCollider boundary in boundaryColliders)
        {
            if (boundary == null) continue;

            // Calculate the world space boundaries of the current Box Collider
            Vector3 minBounds = boundary.bounds.min;
            Vector3 maxBounds = boundary.bounds.max;

            // Clamp the position to stay within this Box Collider
            float clampedX = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);
            float clampedZ = Mathf.Clamp(position.z, minBounds.z, maxBounds.z);

            Vector3 clampedPosition = new Vector3(clampedX, clampedY, clampedZ);

            // Calculate the distance from the original position to the clamped position
            float distance = Vector3.Distance(position, clampedPosition);

            // Use the closest valid position
            if (distance < closestDistance)
            {
                closestDistance = distance;
                finalPosition = clampedPosition;
            }
        }

        return finalPosition;
    }

    void OnDrawGizmos()
    {
        if (holder != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(holder.position + holder.forward * holdDistance, radius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        // Draw the Box Collider boundaries in yellow
        if (boundaryColliders != null)
        {
            Gizmos.color = Color.yellow;
            foreach (BoxCollider boundary in boundaryColliders)
            {
                if (boundary != null)
                {
                    Gizmos.DrawWireCube(boundary.bounds.center, boundary.bounds.size);
                }
            }
        }
    }
}
