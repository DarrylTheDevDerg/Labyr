using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseWithDistance : MonoBehaviour
{
    public string playerTag = "Player"; // The tag of the player object to chase
    public float chaseSpeed = 5f;       // The speed at which the object chases the player
    public float maintainDistance = 5f; // The desired distance to maintain from the player
    public float backingSpeed = 3f;     // The speed at which the object backs away

    private Transform player;           // Reference to the player's transform
    private bool backingAway = false;   // Flag to indicate if the object is backing away

    private void Start()
    {
        // Find the player GameObject using its tag
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        // Check if the player was found and has a transform component
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player with tag '" + playerTag + "' not found.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the current position to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Calculate the distance to the player
            float distanceToPlayer = directionToPlayer.magnitude;

            if (!backingAway)
            {
                // Check if the distance to the player is greater than the desired distance
                if (distanceToPlayer > maintainDistance)
                {
                    // Calculate the movement direction
                    Vector3 moveDirection = directionToPlayer.normalized;

                    // Calculate the new position based on the chase speed
                    Vector3 newPosition = transform.position + moveDirection * chaseSpeed * Time.deltaTime;

                    // Move towards the new position
                    transform.position = newPosition;
                }
            }
            else
            {
                // Back away from the player
                Vector3 moveDirection = -directionToPlayer.normalized;
                Vector3 newPosition = transform.position + moveDirection * backingSpeed * Time.deltaTime;
                transform.position = newPosition;

                // If the player returns to within the desired distance, stop backing away
                if (distanceToPlayer <= maintainDistance)
                {
                    backingAway = false;
                }
            }

            // Rotate to look at the player
            transform.LookAt(player);
        }
    }

    // Draw a sphere gizmo to visualize the desired distance
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maintainDistance);
    }

    // Detect when the player surpasses the maintain distance area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            backingAway = true;
        }
    }
}
