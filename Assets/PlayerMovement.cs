using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento

    // Update se llama una vez por frame
    void Update()
    {
        // Obtener entradas del teclado (W, A, S, D)
        float horizontal = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        float vertical = Input.GetAxis("Vertical"); // W/S o flechas arriba/abajo

        // Crear un vector de movimiento en 3D
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);

        // Mover al jugador
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
