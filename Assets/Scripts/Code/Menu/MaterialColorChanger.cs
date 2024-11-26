using UnityEngine;

public class MaterialColorChanger : MonoBehaviour
{
    public Renderer objectRenderer;     // Renderer del objeto cuyo material queremos cambiar.
    public float colorChangeSpeed = 1f; // Velocidad de cambio de color.
    private Color targetColor;         // Color objetivo para la interpolaci�n.
    private Material objectMaterial;   // El material del objeto para poder manipular la emisi�n.

    void Start()
    {
        // Si no se asign� un Renderer en el Inspector, lo obtenemos autom�ticamente.
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
        }

        // Inicializamos el material y habilitamos la emisi�n.
        objectMaterial = objectRenderer.material;
        objectMaterial.EnableKeyword("_EMISSION");  // Activamos la emisi�n

        // Inicializamos con un color aleatorio de estilo arco�ris.
        SetRandomRainbowColor();
    }

    void Update()
    {
        // Interpolamos entre el color actual y el color objetivo.
        objectMaterial.color = Color.Lerp(objectMaterial.color, targetColor, colorChangeSpeed * Time.deltaTime);

        // Actualizamos el color de emisi�n para que tambi�n cambie con el color base
        objectMaterial.SetColor("_EmissionColor", targetColor * 4f);  // Aumentamos la intensidad para un efecto ne�n m�s fuerte

        // Si la diferencia entre el color actual y el objetivo es peque�a, cambiamos el objetivo a un color aleatorio.
        if (Vector4.Distance(objectMaterial.color, targetColor) < 0.1f)
        {
            SetRandomRainbowColor();
        }
    }

    // Funci�n para establecer un color aleatorio dentro del espectro del arco�ris
    private void SetRandomRainbowColor()
    {
        // Generar un color aleatorio en el rango del arco�ris (usando el matiz)
        float randomHue = Random.value;  // Esto generar� un valor entre 0 y 1 para obtener un color aleatorio en el arco�ris
        Color rainbowColor = Color.HSVToRGB(randomHue, 1f, 1f);  // Saturaci�n y brillo al m�ximo

        targetColor = rainbowColor;

        // Aseguramos que el color de emisi�n se actualice para hacerlo brillar.
        objectMaterial.SetColor("_EmissionColor", targetColor * 4f);  // Aumentamos la intensidad para un resplandor m�s fuerte
    }
}
