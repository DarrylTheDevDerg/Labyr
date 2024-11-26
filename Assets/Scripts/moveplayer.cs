using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class moveplayer : MonoBehaviour
{
    [Header("Main settings")]
    public float velocidad = 5.0f; // Velocidad de movimiento del jugador
    public string groundTag = "Ground";
    public float sprintSpd = 1.0f;
    public CinemachineVirtualCamera virtualCamera;

    private Rigidbody rb;
    private bool sprintMode;
    Vector3 movimiento;
    private float y;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        y = rb.position.y;
    }

    private void Update()
    {
        // Obtén las entradas del eje horizontal (izquierda/derecha) y vertical (arriba/abajo)
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 extra;

        // Calcula el vector de movimiento basado en las entradas
        movimiento = movimientoVertical * new Vector3(virtualCamera.transform.forward.x, 0, virtualCamera.transform.forward.z);
        

        // Si hay entrada de movimiento

        /*
        if (movimientoHorizontal != 0)
        {
            Vector3 currentR = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(currentR.x, currentR.y + movimientoHorizontal * Time.deltaTime * velocidadRotacion, currentR.z);
            
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

        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetAxis("Horizontal") > 0 || (Input.GetAxis("Horizontal") < 0))
            {
                extra = movimientoHorizontal * new Vector3(virtualCamera.transform.right.x, 0, virtualCamera.transform.right.z);
                movimiento += extra;
            }

        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0 || (Input.GetAxis("Horizontal") < 0))
            {
                movimiento = movimientoHorizontal * new Vector3(virtualCamera.transform.right.x, 0, virtualCamera.transform.right.z);
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.LeftShift) && !sprintMode)
        {
            velocidad += sprintSpd;
            sprintMode = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && sprintMode)
        {
            velocidad -= sprintSpd;
            sprintMode = false;
        }
        */
    }

    public void FixedUpdate()
    {
        // Mueve al jugador en la dirección del movimiento
        // transform.position += (movimiento * velocidad * Time.deltaTime);
        rb.MovePosition(transform.position + (movimiento * velocidad * Time.deltaTime)); 
    }
}
