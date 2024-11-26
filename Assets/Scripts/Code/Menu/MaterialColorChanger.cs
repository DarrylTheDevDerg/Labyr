using UnityEngine;

public class MaterialColorChanger : MonoBehaviour
{
    public Renderer objectRenderer;     // Renderer del objeto cuyo material queremos cambiar.
    public float colorChangeSpeed = 1f; // Velocidad de cambio de color.
    private Color targetColor;         // Color objetivo para la interpolación.
    private Material objectMaterial;   // El material del objeto para poder manipular la emisión.

    void Start()
    {
        // Si no se asignó un Renderer en el Inspector, lo obtenemos automáticamente.
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
        }

        // Inicializamos el material y habilitamos la emisión.
        objectMaterial = objectRenderer.material;
        objectMaterial.EnableKeyword("_EMISSION");  // Activamos la emisión

        // Inicializamos con un color aleatorio de estilo arcoíris.
        SetRandomRainbowColor();
    }

    void Update()
    {
        // Interpolamos entre el color actual y el color objetivo.
        objectMaterial.color = Color.Lerp(objectMaterial.color, targetColor, colorChangeSpeed * Time.deltaTime);

        // Actualizamos el color de emisión para que también cambie con el color base
        objectMaterial.SetColor("_EmissionColor", targetColor * 4f);  // Aumentamos la intensidad para un efecto neón más fuerte

        // Si la diferencia entre el color actual y el objetivo es pequeña, cambiamos el objetivo a un color aleatorio.
        if (Vector4.Distance(objectMaterial.color, targetColor) < 0.1f)
        {
            SetRandomRainbowColor();
        }
    }

    // Función para establecer un color aleatorio dentro del espectro del arcoíris
    private void SetRandomRainbowColor()
    {
        // Generar un color aleatorio en el rango del arcoíris (usando el matiz)
        float randomHue = Random.value;  // Esto generará un valor entre 0 y 1 para obtener un color aleatorio en el arcoíris
        Color rainbowColor = Color.HSVToRGB(randomHue, 1f, 1f);  // Saturación y brillo al máximo

        targetColor = rainbowColor;

        // Aseguramos que el color de emisión se actualice para hacerlo brillar.
        objectMaterial.SetColor("_EmissionColor", targetColor * 4f);  // Aumentamos la intensidad para un resplandor más fuerte
    }
}
