using UnityEngine;
using UnityEngine.SceneManagement;

public class ZeroEnemies : MonoBehaviour
{
    public string objectTag = "Enemy"; // El Tag de los objetos a contar
    public string nextSceneName = "NextScene"; // El nombre de la siguiente escena

    void Update()
    {
        // Cuenta cuántos objetos con el Tag especificado hay en la escena
        int objectCount = GameObject.FindGameObjectsWithTag(objectTag).Length;

        // Verifica si no quedan objetos con el Tag "Enemy"
        if (objectCount == 0)
        {
            // Cambia a la siguiente escena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
