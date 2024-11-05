using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCounter : MonoBehaviour
{
    public string objectTag = "Enemy"; // El Tag de los objetos a contar
    public int minimumObjects = 0; // El n�mero m�nimo de objetos
    public int maxObjects; // El n�mero m�ximo de objetos en la sala (definido en el inicio)
    public string nextSceneName = "NextScene"; // El nombre de la siguiente escena

    private void Start()
    {
        // Inicializa el n�mero m�ximo de objetos al inicio
        maxObjects = GameObject.FindGameObjectsWithTag(objectTag).Length;
    }

    void Update()
    {
        // Cuenta cu�ntos objetos con el Tag especificado hay en la escena
        int objectCount = GameObject.FindGameObjectsWithTag(objectTag).Length;

        // Calcular el 10% del n�mero m�ximo de objetos
        int tenPercentOfMax = Mathf.CeilToInt(maxObjects * 0.1f);

        // Verifica si el n�mero de objetos ha ca�do por debajo del 10% del m�ximo
        if (objectCount <= Mathf.Max(tenPercentOfMax, minimumObjects))
        {
            // Cambia a la siguiente escena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
