using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public GameObject background1; // Primer fondo
    public GameObject background2; // Segundo fondo
    public float scrollSpeed = 2.0f; // Velocidad del desplazamiento

    private float backgroundWidth; // Ancho del fondo

    private void Start()
    {
        // Calcular el ancho del primer fondo
        backgroundWidth = background1.GetComponent<Renderer>().bounds.size.x;
    }

    private void Update()
    {
        // Desplazar los fondos hacia la izquierda
        background1.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        background2.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Ajustar la posición de reinicio para el fondo 1
        if (background1.transform.position.x < -backgroundWidth)
        {
            background1.transform.position = new Vector3(background2.transform.position.x + backgroundWidth, background1.transform.position.y, background1.transform.position.z);
        }

        // Ajustar la posición de reinicio para el fondo 2
        if (background2.transform.position.x < -backgroundWidth)
        {
            background2.transform.position = new Vector3(background1.transform.position.x + backgroundWidth, background2.transform.position.y, background2.transform.position.z);
        }
    }
}
