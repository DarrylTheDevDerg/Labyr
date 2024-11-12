using UnityEngine;
using UnityEngine.Events;

public class TouchPanel : MonoBehaviour
{
    public float detectionRadius = 3f, timel;  // Radio de detecci�n alrededor del cubo
    public bool playerInRange = false, timed; // Si el jugador est� dentro del �rea de interacci�n
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
        // Si el jugador entra en el �rea de detecci�n (el cubo)
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Jugador dentro del �rea de interacci�n");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del �rea de detecci�n
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Jugador fuera del �rea de interacci�n");
        }
    }

    // Cambiar a p�blico para que se pueda llamar desde otros scripts
    public void InteractWithPanel()
    {
        Debug.Log("Panel interactuado con la tecla E");
        // Aqu� puedes agregar la acci�n que deseas realizar cuando el jugador interact�e con el panel
        trigger.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
