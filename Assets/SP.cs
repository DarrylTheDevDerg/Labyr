using UnityEditor;
using UnityEngine;

public class SP : MonoBehaviour
{
    public GameObject SP_ObjectToSpawn;  // El prefab del objeto a spawnear
    public Transform SP_SpawnLocation;   // Ubicaci�n desde donde aparecer� el objeto
    public float SP_SpawnRadius = 5f, limit;    // Radio en el que el objeto puede aparecer
    private float current;

    // M�todo que instancia un objeto en el mundo
    public void SP_SpawnObject()
    {
        if (SP_ObjectToSpawn != null && current < limit)
        {
            // Seleccionamos una posici�n aleatoria dentro de un rango (usando SP_SpawnRadius)
            Vector3 spawnPosition = SP_SpawnLocation.position + new Vector3(Random.Range(-SP_SpawnRadius, SP_SpawnRadius), 0, Random.Range(-SP_SpawnRadius, SP_SpawnRadius));

            // Instanciamos el objeto en la posici�n seleccionada
            Instantiate(SP_ObjectToSpawn, spawnPosition, Quaternion.identity);  // Quaternion.identity significa sin rotaci�n
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
