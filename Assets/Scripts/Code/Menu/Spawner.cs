using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // El objeto que se va a spawnear
    public float spawnInterval = 3f;  // Intervalo de tiempo en segundos para hacer el spawn
    private float timer = 0f;         // Temporizador para controlar el intervalo
    public int maxObjects = 10;       // Límite máximo de objetos en la escena
    private int currentObjectCount = 0; // Contador de objetos actuales

    void Update()
    {
        // Aumentamos el temporizador con el tiempo que ha pasado desde el último frame
        timer += Time.deltaTime;

        // Si el temporizador alcanza el intervalo de spawn y no hemos alcanzado el límite de objetos
        if (timer >= spawnInterval && currentObjectCount < maxObjects)
        {
            SpawnObject();
            timer = 0f;  // Reiniciar el temporizador
        }
    }

    void SpawnObject()
    {
        // Instanciamos el objeto en la posición del spawner
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);

        // Incrementamos el contador de objetos
        currentObjectCount++;
    }

    // Método para reducir el contador cuando un objeto es destruido manualmente (si es necesario)
    public void ObjectDestroyed()
    {
        // Si algún objeto es destruido por alguna razón, decrementar el contador
        currentObjectCount--;
    }
}
