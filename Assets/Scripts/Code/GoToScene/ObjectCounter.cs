using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCounter : MonoBehaviour
{
    public string objectTag = "Enemy"; // El Tag de los objetos a contar
    public int minimumObjects = 0; // El número mínimo de objetos
    public int maxObjects; // El número máximo de objetos en la sala (definido en el inicio)
    public string nextSceneName = "NextScene"; // El nombre de la siguiente escena

    private void Start()
    {
        // Inicializa el número máximo de objetos al inicio
        maxObjects = GameObject.FindGameObjectsWithTag(objectTag).Length;
    }

    void Update()
    {
        // Cuenta cuántos objetos con el Tag especificado hay en la escena
        int objectCount = GameObject.FindGameObjectsWithTag(objectTag).Length;

        // Calcular el 10% del número máximo de objetos
        int tenPercentOfMax = Mathf.CeilToInt(maxObjects * 0.1f);

        // Verifica si el número de objetos ha caído por debajo del 10% del máximo
        if (objectCount <= Mathf.Max(tenPercentOfMax, minimumObjects))
        {
            // Cambia a la siguiente escena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
