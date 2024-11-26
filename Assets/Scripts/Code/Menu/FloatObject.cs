using UnityEngine;

public class FlyCube : MonoBehaviour
{
    public float upwardForce = 10f;  // Fuerza que impulsa el cubo hacia arriba
    public float gravityMultiplier = 0.1f;  // Multiplicador de gravedad para reducir la ca�da

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;  // Aseguramos que la gravedad afecte al cubo
    }

    void FixedUpdate()
    {
        // Aplica una fuerza constante hacia arriba
        rb.AddForce(Vector3.up * upwardForce, ForceMode.Acceleration);

        // Reducir la gravedad si es necesario para evitar que el cubo caiga demasiado r�pido
        rb.AddForce(Vector3.down * gravityMultiplier * rb.mass, ForceMode.Acceleration);
    }
}
