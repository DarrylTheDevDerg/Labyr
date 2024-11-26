using UnityEngine;

public class FreeMode : MonoBehaviour
{
    private CameraOrbit cameraOrbit;  // Referencia al script de movimiento de la cámara
    public GameObject[] objectsToDeactivate;  // Array de objetos a desactivar (botones, paneles, etc.)
    public GameObject returnButton;  // Botón de "Volver" que se activa

    void Start()
    {
        // Obtenemos el componente CameraOrbit en el mismo objeto
        cameraOrbit = GetComponent<CameraOrbit>();

        if (cameraOrbit == null)
        {
            Debug.LogError("CameraOrbit no se encontró en el mismo objeto.");
        }
    }

    // Método para pausar el movimiento de la cámara y activar el botón de "Volver"
    public void PauseMovement()
    {
        if (cameraOrbit != null)
        {
            cameraOrbit.enabled = false;
        }

        // Desactivar objetos actuales del Canvas
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }

        // Activar el botón de "Volver"
        returnButton.SetActive(true);
    }

    // Método para reanudar el movimiento de la cámara y restaurar el Canvas
    public void ResumeMovement()
    {
        if (cameraOrbit != null)
        {
            cameraOrbit.enabled = true;
        }

        // Desactivar el botón de "Volver"
        returnButton.SetActive(false);

        // Activar los objetos originales del Canvas
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(true);
        }
    }
}
