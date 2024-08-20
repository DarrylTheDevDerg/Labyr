using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : MonoBehaviour
{
    public string targetTag = "Player";  // The tag of the target to chase
    public float speed = 5f;             // The chase speed

    public float minSpeed;
    public float maxSpeed;

    private Transform target;            // Reference to the target's transform

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);

        // Find the target GameObject using its tag
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);

        // Check if the target was found and has a transform component
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
        else
        {
            Debug.LogWarning("Target with tag '" + targetTag + "' not found.");
        }
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the current position to the target position
            Vector3 direction = (target.position - transform.position).normalized;

            // Calculate the new position based on the chase speed and time
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

            // Move towards the new position
            transform.position = newPosition;
        }
    }
}
