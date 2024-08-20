using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float followSpeed = 5f; // Speed at which the object follows the target

    private void Update()
    {
        if (target != null)
        {
            // Calculate the new position with only the X-axis updated
            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Lerp(transform.position.x, target.position.x, followSpeed * Time.deltaTime);

            // Update the object's position
            transform.position = newPosition;
        }
    }
}
