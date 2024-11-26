using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;         // El objetivo alrededor del cual girará la cámara (puedes asignar un objeto en el Inspector)
    public float distance = 10f;     // Distancia a la que la cámara se mantiene del objetivo
    public float rotationSpeed = 50f; // Velocidad de rotación, se puede ajustar en el Inspector

    private float currentAngle = 0f; // Ángulo actual de la cámara

    void Update()
    {
        if (target != null)
        {
            // Actualizamos el ángulo basado en la velocidad de rotación
            currentAngle += rotationSpeed * Time.deltaTime;

            // Calculamos la nueva posición de la cámara en función del ángulo
            float radians = currentAngle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Sin(radians) * distance, 0f, Mathf.Cos(radians) * distance);

            // Actualizamos la posición de la cámara
            transform.position = target.position + offset;

            // Hacemos que la cámara siempre mire al objetivo
            transform.LookAt(target);
        }
    }
}
