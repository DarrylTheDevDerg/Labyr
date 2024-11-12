using UnityEngine;
using UnityEngine.Events;

public class TouchPanel : MonoBehaviour
{
    public float detectionRadius = 3f, timel;  // Radio de detección alrededor del cubo
    public bool playerInRange = false, timed; // Si el jugador está dentro del área de interacción
    public UnityEvent trigger;
    public KeyCode key;

    private float time;

    private void Update()
    {
        if(Input.GetKeyDown(key) || time > timel)
        {
            InteractWithPanel();
            time = 0;
        }

        if (Input.GetKey(key) && timed)
        {
            time += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el área de detección (el cubo)
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Jugador dentro del área de interacción");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del área de detección
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Jugador fuera del área de interacción");
        }
    }

    // Cambiar a público para que se pueda llamar desde otros scripts
    public void InteractWithPanel()
    {
        Debug.Log("Panel interactuado con la tecla E");
        // Aquí puedes agregar la acción que deseas realizar cuando el jugador interactúe con el panel
        trigger.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
