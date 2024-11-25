using UnityEngine;

public class Hold : MonoBehaviour
{
    [Header("Grab Settings")]
    public float grabDistance = 3.0f;
    public float holdDistance = 1.5f;
    public float grabSmoothness = 10.0f;
    public LayerMask grabbableLayer;
    public LayerMask collisionLayer;
    public string boxTag;

    private Transform playerCamera;
    private Transform grabbedObject = null;
    private Rigidbody grabbedObjectRb;
    private GameObject grabBoundary; // New: Extra collider boundary
    private float origMass;

    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    void Update()
    {
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

        if (grabbedObject != null)
        {
            MoveObjectWithCamera();
        }
    }

    void TryGrabObject()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, grabDistance, grabbableLayer))
        {
            grabbedObject = hit.transform;
            grabbedObjectRb = grabbedObject.GetComponent<Rigidbody>();

            if (grabbedObjectRb != null)
            {
                
                grabbedObjectRb.useGravity = false;
                grabbedObjectRb.freezeRotation = true;

                //grabbedObjectRb.isKinematic = true;

                // Add an extra collider boundary
                grabBoundary = new GameObject("GrabBoundary");
                grabBoundary.transform.parent = grabbedObject;
                grabBoundary.transform.localPosition = Vector3.zero;

                // Add a BoxCollider to serve as the "wall"
                BoxCollider boundaryCollider = grabBoundary.AddComponent<BoxCollider>();
                boundaryCollider.size = grabbedObject.localScale * 1.5f; // Adjust based on size
                boundaryCollider.isTrigger = false; // Acts as a solid boundary
            }
        }
    }

    void ReleaseObject()
    {
        if (grabbedObjectRb != null)
        {
            
            grabbedObjectRb.useGravity = true;
            grabbedObjectRb.freezeRotation = false;
            
            //grabbedObjectRb.isKinematic = false;
            grabbedObjectRb = null;
        }

        // Remove the boundary collider when releasing the object
        if (grabBoundary != null)
        {
            Destroy(grabBoundary);
            grabBoundary = null;
        }

        grabbedObject = null;
    }

    void MoveObjectWithCamera()
    {
        Vector3 targetPosition = playerCamera.position + playerCamera.forward * holdDistance;

        if (!IsPathBlocked(targetPosition))
        {
            grabbedObject.position = Vector3.Lerp(grabbedObject.position, targetPosition, Time.deltaTime * grabSmoothness);
        }
        else
        {
            grabbedObject.position = FindSafePosition();
        }
    }

    
    bool IsPathBlocked(Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - grabbedObject.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (Physics.BoxCast(grabbedObject.position, grabbedObject.localScale / 2, directionToTarget.normalized, out RaycastHit hit, Quaternion.identity, distanceToTarget, collisionLayer))
        {
            return true;
        }
        return false;
    }

    Vector3 FindSafePosition()
    {
        Vector3 directionToObject = grabbedObject.position - playerCamera.position;
        float maxDistance = holdDistance;

        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, directionToObject.normalized, out hit, maxDistance, collisionLayer))
        {
            return hit.point - directionToObject.normalized * 0.1f;
        }
        return playerCamera.position + playerCamera.forward * holdDistance;
    }
    
}

