using UnityEngine;
using UnityEngine.Events;

public class TouchPanel : MonoBehaviour
{
    public float timel;  // Radio de detección alrededor del cubo
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

    private void OnDrawGizmos()
    {
        SphereCollider collider = GetComponent<SphereCollider>();

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, collider.radius);
    }
}
