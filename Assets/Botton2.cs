using UnityEngine;

public class Button2 : MonoBehaviour
{
    public float timeToDeactivate = 3f;  // Tiempo en segundos para que el botón se apague si no hay interacción
    private bool isPressed = false;      // Si el botón está presionado
    private Renderer buttonRenderer;     // Para cambiar el color del botón
    private float timer = 0f;            // Temporizador para saber cuándo desactivar el botón

    private void Start()
    {
        // Obtener el renderer del botón para poder cambiar el color
        buttonRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entra en el área de colisión es el jugador o un objeto con el tag "Object"
        if (other.CompareTag("Player") || other.CompareTag("Object"))
        {
            ActivateButton();  // Activamos el botón
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificamos si el objeto que sale es el jugador o un objeto con el tag "Object"
        if (other.CompareTag("Player") || other.CompareTag("Object"))
        {
            // Si el objeto que salió es el jugador o el objeto con el tag "Object", comenzamos a contar para desactivar el botón
            timer = timeToDeactivate;
        }
    }

    // Método para activar el botón (presionado)
    void ActivateButton()
    {
        if (!isPressed)
        {
            isPressed = true;
            Debug.Log("¡Botón 2 presionado!");

            // Cambiar el color del botón al activarlo
            buttonRenderer.material.color = Color.green;

            // Aquí puedes agregar otras acciones que deseas ejecutar cuando el botón se activa
        }
    }

    private void Update()
    {
        // Si el botón ha sido presionado y el jugador ya no está sobre él o el objeto salió
        if (isPressed && timer > 0)
        {
            timer -= Time.deltaTime;  // Restar el tiempo transcurrido

            // Si el tiempo se agota, desactivamos el botón
            if (timer <= 0)
            {
                DeactivateButton();
            }
        }
    }

    // Método para desactivar el botón (volver a su estado original)
    void DeactivateButton()
    {
        isPressed = false;
        buttonRenderer.material.color = Color.red;  // Cambiar el color del botón a rojo (o cualquier color que desees)
        Debug.Log("Botón 2 desactivado por inactividad");

        // Aquí puedes agregar otras acciones que desees ejecutar cuando el botón se desactiva
    }
}
