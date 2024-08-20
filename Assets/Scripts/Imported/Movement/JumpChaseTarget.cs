using UnityEngine;

public class JumpChaseTarget : MonoBehaviour
{
    public string targetTag = "Player";  // The tag of the target to chase
    public float chaseSpeed = 5f;       // The chase speed
    public float jumpForce = 10f;       // The force applied for jumping
    public float jumpInterval = 2f;     // The interval between jumps

    private Transform target;            // Reference to the target's transform
    private float jumpTimer = 0f;       // Timer to control jumping

    private void Start()
    {
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
            Vector3 newPosition = transform.position + direction * chaseSpeed * Time.deltaTime;

            // Move towards the new position
            transform.position = newPosition;

            // Jump routine
            JumpRoutine();
        }
    }

    private void JumpRoutine()
    {
        // Update the jump timer
        jumpTimer += Time.deltaTime;

        // Check if it's time to jump
        if (jumpTimer >= jumpInterval)
        {
            // Reset the timer
            jumpTimer = 0f;

            // Apply a jump force
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
