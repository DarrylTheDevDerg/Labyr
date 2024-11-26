using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;         // El objetivo alrededor del cual girar� la c�mara (puedes asignar un objeto en el Inspector)
    public float distance = 10f;     // Distancia a la que la c�mara se mantiene del objetivo
    public float rotationSpeed = 50f; // Velocidad de rotaci�n, se puede ajustar en el Inspector

    private float currentAngle = 0f; // �ngulo actual de la c�mara

    void Update()
    {
        if (target != null)
        {
            // Actualizamos el �ngulo basado en la velocidad de rotaci�n
            currentAngle += rotationSpeed * Time.deltaTime;

            // Calculamos la nueva posici�n de la c�mara en funci�n del �ngulo
            float radians = currentAngle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Sin(radians) * distance, 0f, Mathf.Cos(radians) * distance);

            // Actualizamos la posici�n de la c�mara
            transform.position = target.position + offset;

            // Hacemos que la c�mara siempre mire al objetivo
            transform.LookAt(target);
        }
    }
}
