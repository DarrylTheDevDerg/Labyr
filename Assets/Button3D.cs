using UnityEngine;

public class Button3D : MonoBehaviour
{
    public bool isPressed = false;       // Para saber si el botón ha sido presionado
    private Renderer buttonRenderer;     // Para cambiar el color del botón

    // Usamos OnTriggerEnter para detectar cuando un objeto pasa por encima del botón
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
            PressButton();  // Llamamos al método para presionar el botón
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificamos si el objeto que sale es el jugador o un objeto con el tag "Object"
        if (other.CompareTag("Player") || other.CompareTag("Object"))
        {
            // Si deseas que el botón vuelva a su estado original cuando el objeto salga, puedes agregar esa lógica aquí.
            // Pero si quieres que el botón se quede presionado, simplemente no pongas nada aquí.
        }
    }

    // Método para simular que el botón se presiona
    void PressButton()
    {
        if (!isPressed)
        {
            isPressed = true;
            Debug.Log("¡Botón 3D presionado!");

            // Cambiar el color del botón al presionarlo (puedes personalizar la acción)
            buttonRenderer.material.color = Color.green;

            // Aquí puedes agregar otras acciones como activar algo en el juego, reproducir un sonido, etc.
        }
    }

    // Si en algún momento decides querer resetear el botón, puedes llamar a ResetButton.
    public void ResetButton()
    {
        if (isPressed)
        {
            isPressed = false;
            // Restaurar el color original del botón
            buttonRenderer.material.color = Color.red;
            Debug.Log("Botón 3D reseteado");
        }
    }
}
