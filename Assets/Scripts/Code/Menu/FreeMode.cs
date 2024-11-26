using UnityEngine;

public class FreeMode : MonoBehaviour
{
    private CameraOrbit cameraOrbit;  // Referencia al script de movimiento de la c�mara
    public GameObject[] objectsToDeactivate;  // Array de objetos a desactivar (botones, paneles, etc.)
    public GameObject returnButton;  // Bot�n de "Volver" que se activa

    void Start()
    {
        // Obtenemos el componente CameraOrbit en el mismo objeto
        cameraOrbit = GetComponent<CameraOrbit>();

        if (cameraOrbit == null)
        {
            Debug.LogError("CameraOrbit no se encontr� en el mismo objeto.");
        }
    }

    // M�todo para pausar el movimiento de la c�mara y activar el bot�n de "Volver"
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

        // Activar el bot�n de "Volver"
        returnButton.SetActive(true);
    }

    // M�todo para reanudar el movimiento de la c�mara y restaurar el Canvas
    public void ResumeMovement()
    {
        if (cameraOrbit != null)
        {
            cameraOrbit.enabled = true;
        }

        // Desactivar el bot�n de "Volver"
        returnButton.SetActive(false);

        // Activar los objetos originales del Canvas
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(true);
        }
    }
}
