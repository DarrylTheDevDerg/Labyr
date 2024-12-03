using UnityEngine;
using UnityEngine.Events;

public class TouchPanel : MonoBehaviour
{
    public float timel;  // Radio de detecci�n alrededor del cubo
    public bool playerInRange = false, timed, once; // Si el jugador est� dentro del �rea de interacci�n
    public UnityEvent trigger;
    public KeyCode key;

    private float time;
    private bool done;

    private void Update()
    {
        if(Input.GetKeyDown(key) && !done && playerInRange || time > timel && !done && playerInRange)
        {
            InteractWithPanel();
            time = 0;

            if (once)
            {
                done = true;
            }
        }

        if (Input.GetKey(key) && timed && !done)
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del �rea de detecci�n
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    // Cambiar a p�blico para que se pueda llamar desde otros scripts
    public void InteractWithPanel()
    {
        // Aqu� puedes agregar la acci�n que deseas realizar cuando el jugador interact�e con el panel
        if (playerInRange)
        {
            trigger.Invoke();
        }
    }
}
