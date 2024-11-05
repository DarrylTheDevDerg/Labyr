using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float followDistance = 2f; // Distancia a la que el objeto debe mantenerse
    public float followSpeed = 2f; // Velocidad a la que el objeto se mueve hacia el jugador
    public float detectionRange = 10f; // Distancia de detección para empezar a seguir al jugador
    public bool lookAtPlayer = true; // Opción para rotar hacia el jugador
    public bool constrainYAxis = true; // Opción para ignorar el eje Y

    void Update()
    {
        // Calcular la dirección hacia el jugador
        Vector3 direction = player.position - transform.position;

        // Si queremos ignorar el eje Y (por ejemplo, en un juego 2.5D o top-down)
        if (constrainYAxis)
        {
            direction.y = 0f; // No seguir en el eje Y
        }

        // Obtener la distancia actual al jugador
        float distance = direction.magnitude;

        // Verificar si el jugador está dentro del rango de detección
        if (distance <= detectionRange)
        {
            // Solo sigue al jugador si está más lejos que la distancia deseada
            if (distance > followDistance)
            {
                // Normalizar la dirección y calcular la posición objetivo
                direction.Normalize();
                Vector3 targetPosition = player.position - direction * followDistance;

                // Mover el objeto suavemente hacia la posición objetivo
                transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            }

            // Si la opción lookAtPlayer está habilitada, rotar hacia el jugador
            if (lookAtPlayer)
            {
                // Rotar suavemente hacia el jugador
                Vector3 lookDirection = player.position - transform.position;
                if (constrainYAxis)
                {
                    lookDirection.y = 0f; // Ignorar la rotación en Y si está habilitado
                }
                if (lookDirection != Vector3.zero) // Evitar errores si las posiciones coinciden
                {
                    Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
                }
            }
        }
    }
}
