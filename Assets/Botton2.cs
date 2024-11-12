using UnityEngine;

public class Button2 : MonoBehaviour
{
    public float timeToDeactivate = 3f;  // Tiempo en segundos para que el bot�n se apague si no hay interacci�n
    private bool isPressed = false;      // Si el bot�n est� presionado
    private Renderer buttonRenderer;     // Para cambiar el color del bot�n
    private float timer = 0f;            // Temporizador para saber cu�ndo desactivar el bot�n

    private void Start()
    {
        // Obtener el renderer del bot�n para poder cambiar el color
        buttonRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entra en el �rea de colisi�n es el jugador o un objeto con el tag "Object"
        if (other.CompareTag("Player") || other.CompareTag("Object"))
        {
            ActivateButton();  // Activamos el bot�n
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificamos si el objeto que sale es el jugador o un objeto con el tag "Object"
        if (other.CompareTag("Player") || other.CompareTag("Object"))
        {
            // Si el objeto que sali� es el jugador o el objeto con el tag "Object", comenzamos a contar para desactivar el bot�n
            timer = timeToDeactivate;
        }
    }

    // M�todo para activar el bot�n (presionado)
    void ActivateButton()
    {
        if (!isPressed)
        {
            isPressed = true;
            Debug.Log("�Bot�n 2 presionado!");

            // Cambiar el color del bot�n al activarlo
            buttonRenderer.material.color = Color.green;

            // Aqu� puedes agregar otras acciones que deseas ejecutar cuando el bot�n se activa
        }
    }

    private void Update()
    {
        // Si el bot�n ha sido presionado y el jugador ya no est� sobre �l o el objeto sali�
        if (isPressed && timer > 0)
        {
            timer -= Time.deltaTime;  // Restar el tiempo transcurrido

            // Si el tiempo se agota, desactivamos el bot�n
            if (timer <= 0)
            {
                DeactivateButton();
            }
        }
    }

    // M�todo para desactivar el bot�n (volver a su estado original)
    void DeactivateButton()
    {
        isPressed = false;
        buttonRenderer.material.color = Color.red;  // Cambiar el color del bot�n a rojo (o cualquier color que desees)
        Debug.Log("Bot�n 2 desactivado por inactividad");

        // Aqu� puedes agregar otras acciones que desees ejecutar cuando el bot�n se desactiva
    }
}
