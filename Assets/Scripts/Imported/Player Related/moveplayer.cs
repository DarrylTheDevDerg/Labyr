using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer : MonoBehaviour
{
    [Header("Main settings")]
    public float velocidad = 5.0f; // Velocidad de movimiento del jugador
    public string groundTag = "Ground";
    public float jumpForce = 10f;
    public int extraJumps;
    public float sprintSpd = 1.0f;

    private Quaternion rotacionDeseada;
    private float velocidadRotacion = 360.0f; // Velocidad de rotación en grados por segundo
    private Quaternion rotacionOriginal;
    private bool midair;
    private Rigidbody rb;
    private int jumpCount;
    private bool sprintMode;
    Vector3 movimiento;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Guarda la rotación original del jugador al inicio
        rotacionOriginal = transform.rotation;

        jumpCount = extraJumps;
    }

    private void Update()
    {
        // Obtén las entradas del eje horizontal (izquierda/derecha) y vertical (arriba/abajo)
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcula el vector de movimiento basado en las entradas
        movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);

        // Si hay entrada de movimiento
        /*
        if (movimiento != Vector3.zero)
        {
            // Calcula la dirección deseada en base al vector de movimiento
            Vector3 direccionDeseada = new Vector3(
                Mathf.Round(movimiento.x),
                0.0f,
                Mathf.Round(movimiento.z)
            ).normalized;

            // Evita que el vector dirección quede en (0,0,0)
            if (direccionDeseada != Vector3.zero)
            {
                // Establece la rotación deseada hacia la dirección deseada
                Quaternion rotacionDeseada = Quaternion.LookRotation(direccionDeseada, Vector3.up);

                // Realiza la rotación hacia la rotación deseada de forma gradual
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    rotacionDeseada,
                    velocidadRotacion * Time.deltaTime
                );
            }
        }
        */

            if (Input.GetKeyDown(KeyCode.Space) && !midair)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            midair = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && midair && jumpCount > 0)
        {
            ExtraJump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !sprintMode && !midair)
        {
            velocidad += sprintSpd;
            sprintMode = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && sprintMode && !midair)
        {
            velocidad -= sprintSpd;
            sprintMode = false;
        }
        
    }

    public void FixedUpdate()
    {
        // Mueve al jugador en la dirección del movimiento
        // transform.position += (movimiento * velocidad * Time.deltaTime);
        rb.MovePosition(transform.position + (movimiento * velocidad * Time.deltaTime)); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            midair = false;
            jumpCount = extraJumps;
        }
    }

    public void ExtraJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpCount--;
    }
}
