using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Camera mainCamera;         // Para referenciar la cámara principal
    private bool isDragging = false;   // Para verificar si el objeto está siendo arrastrado
    private Vector3 offset;            // Para almacenar la diferencia entre la posición del mouse y el objeto al hacer clic
    private float fixedZ;              // Posición Z fija para ajustar el acercamiento y alejamiento
    private Vector3 grabOffset;        // Desplazamiento para el punto de arrastre
    private Rigidbody rb;              // Referencia al Rigidbody para controlar su física durante el arrastre

    public Vector3 localGrabPoint = new Vector3(0, 0, 0); // Punto de arrastre dentro del objeto
    public float zoomSpeed = 2f;       // Velocidad para acercar/alejar el objeto con la rueda del ratón
    [SerializeField] private Transform centerOfRotation;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        fixedZ = transform.position.z;
        grabOffset = transform.TransformPoint(localGrabPoint) - transform.position;
    }

    void Update()
    {
        // Control de zoom invertido con la rueda del ratón
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            fixedZ -= scrollInput * zoomSpeed; // Invertimos el control del zoom
        }

        // Control de zoom con teclas "O" (acercar) y "P" (alejar)
        if (Input.GetKey(KeyCode.O))
        {
            fixedZ -= zoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.P))
        {
            fixedZ += zoomSpeed * Time.deltaTime;
        }

        // Iniciar el arrastre con clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isDragging = true;
                offset = transform.position - hit.point;
                fixedZ = transform.position.z;

                // Desactivar la física para evitar que el objeto "salga disparado" al soltarlo
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
            }
        }

        if (isDragging)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane dragPlane = new Plane(Vector3.forward, new Vector3(0, 0, fixedZ)); // Plano de arrastre ajustable en Z
            float distance;

            if (dragPlane.Raycast(ray, out distance))
            {
                Vector3 targetPosition = ray.GetPoint(distance) + offset;
                transform.position = new Vector3(targetPosition.x + grabOffset.x, targetPosition.y + grabOffset.y, fixedZ);
                transform.SetParent(centerOfRotation);
            }
        }

        // Soltar el objeto al soltar el clic
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            transform.SetParent(null);

            // Reactivar la física al soltar el objeto
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.velocity = Vector3.zero;       // Cancelar cualquier velocidad residual
                rb.angularVelocity = Vector3.zero; // Cancelar cualquier rotación residual
            }
        }
    }
}
