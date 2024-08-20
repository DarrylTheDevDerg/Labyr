using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private Vector2 lastMousePosition;

    void Start()
    {
        // Lock the mouse cursor within the game window.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Initialize the last mouse position.
        lastMousePosition = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void Update()
    {

        // Get the mouse input.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Update the last mouse position.
        lastMousePosition += new Vector2(mouseX, mouseY);

        // Clamp the last mouse position to screen boundaries.
        lastMousePosition.x = Mathf.Clamp(lastMousePosition.x, 0, Screen.width);
        lastMousePosition.y = Mathf.Clamp(lastMousePosition.y, 0, Screen.height);

        // Print or use the last mouse position.
        transform.rotation *= Quaternion.Euler(0, mouseX * Time.deltaTime * rotationSpeed, 0);
    }

    
}
