using UnityEngine;

public class Button3D : MonoBehaviour
{
    public bool isPressed = false;       // Para saber si el bot�n ha sido presionado
    private Renderer buttonRenderer;     // Para cambiar el color del bot�n

    // Usamos OnTriggerEnter para detectar cuando un objeto pasa por encima del bot�n
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
            PressButton();  // Llamamos al m�todo para presionar el bot�n
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificamos si el objeto que sale es el jugador o un objeto con el tag "Object"
        if (other.CompareTag("Player") || other.CompareTag("Object"))
        {
            // Si deseas que el bot�n vuelva a su estado original cuando el objeto salga, puedes agregar esa l�gica aqu�.
            // Pero si quieres que el bot�n se quede presionado, simplemente no pongas nada aqu�.
        }
    }

    // M�todo para simular que el bot�n se presiona
    void PressButton()
    {
        if (!isPressed)
        {
            isPressed = true;
            Debug.Log("�Bot�n 3D presionado!");

            // Cambiar el color del bot�n al presionarlo (puedes personalizar la acci�n)
            buttonRenderer.material.color = Color.green;

            // Aqu� puedes agregar otras acciones como activar algo en el juego, reproducir un sonido, etc.
        }
    }

    // Si en alg�n momento decides querer resetear el bot�n, puedes llamar a ResetButton.
    public void ResetButton()
    {
        if (isPressed)
        {
            isPressed = false;
            // Restaurar el color original del bot�n
            buttonRenderer.material.color = Color.red;
            Debug.Log("Bot�n 3D reseteado");
        }
    }
}
