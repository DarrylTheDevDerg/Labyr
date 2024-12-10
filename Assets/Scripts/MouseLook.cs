using UnityEngine;
using Cinemachine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] public float mouseSensitivity = 100f;
    [SerializeField] float maxVerticalAngle = 90f;
    [SerializeField] CinemachineVirtualCamera firstPersonCamera;
    [SerializeField] GameObject firstPersonCanvas;

    private float xRotation = 0f;

    void Start()
    {
        ChangeView();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LookAround();
    }

    void LookAround()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust up/down rotation (mouseY) to look up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxVerticalAngle, maxVerticalAngle); // Clamp vertical rotation to prevent over-rotation


        // Rotate player body left and right
        this.transform.Rotate(Vector3.up * mouseX);

        // Apply the vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, transform.localRotation.eulerAngles.y, 0);
    }

    void ChangeView()
    {
        SwitchToFirstPersonView();
    }

    void SwitchToFirstPersonView()
    {
        firstPersonCanvas.gameObject.SetActive(true);
        firstPersonCamera.Priority = 10; // Raise the priority of first-person camera
        // Reset the camera rotation when switching to first-person view
        xRotation = firstPersonCamera.transform.localEulerAngles.x;
    }
}
