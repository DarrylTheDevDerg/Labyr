using UnityEngine;
using UnityEngine.Events;

public class TouchPanel : MonoBehaviour
{
    public float timel;  // Radio de detección alrededor del cubo
    public bool playerInRange = false, timed, once; // Si el jugador está dentro del área de interacción
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
        // Si el jugador entra en el área de detección (el cubo)
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del área de detección
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    // Cambiar a público para que se pueda llamar desde otros scripts
    public void InteractWithPanel()
    {
        // Aquí puedes agregar la acción que deseas realizar cuando el jugador interactúe con el panel
        if (playerInRange)
        {
            trigger.Invoke();
        }
    }
}
