using UnityEditor;
using UnityEngine;

public class SP : MonoBehaviour
{
    public GameObject SP_ObjectToSpawn;  // El prefab del objeto a spawnear
    public Transform SP_SpawnLocation;   // Ubicación desde donde aparecerá el objeto
    public float SP_SpawnRadius = 5f, limit;    // Radio en el que el objeto puede aparecer
    private float current;

    // Método que instancia un objeto en el mundo
    public void SP_SpawnObject()
    {
        if (SP_ObjectToSpawn != null && current < limit)
        {
            // Seleccionamos una posición aleatoria dentro de un rango (usando SP_SpawnRadius)
            Vector3 spawnPosition = SP_SpawnLocation.position + new Vector3(Random.Range(-SP_SpawnRadius, SP_SpawnRadius), 0, Random.Range(-SP_SpawnRadius, SP_SpawnRadius));

            // Instanciamos el objeto en la posición seleccionada
            Instantiate(SP_ObjectToSpawn, spawnPosition, Quaternion.identity);  // Quaternion.identity significa sin rotación
            Debug.Log("Objeto spawnado en: " + spawnPosition);
            current++;
        }
        else
        {
            transform.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, SP_SpawnRadius);
    }
}
