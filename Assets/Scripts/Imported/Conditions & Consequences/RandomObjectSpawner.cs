using System.Collections.Generic;
using UnityEngine;

//SCRIPT HECHO POR CHATGPT

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // An array of prefabs to spawn.
    public int numberOfObjectsToSpawn = 10; // The number of objects to spawn.
    public Transform spawnArea; // The transform defining the spawn area.
    public string playerTag = "Player"; // The tag for the player object.
    public Vector2 rotationRange = new Vector2(0.0f, 360.0f); // Range for randomized Y rotation.

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        if (spawnArea == null)
        {
            Debug.LogError("Spawn area not defined. Please assign a valid Transform.");
            return;
        }

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Generate a random position within the defined spawn area.
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
                0.0f,
                Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2, spawnArea.position.z + spawnArea.localScale.z / 2)
            );

            // Check if the random position is clear of player objects.
            if (!IsPositionOccupied(randomPosition))
            {
                // Choose a random prefab from the array.
                GameObject randomPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

                // Instantiate the object at the random position.
                GameObject spawnedObject = Instantiate(randomPrefab, randomPosition, Quaternion.identity);

                // Randomize the Y rotation.
                float randomYRotation = Random.Range(rotationRange.x, rotationRange.y);
                spawnedObject.transform.rotation = Quaternion.Euler(0, randomYRotation, 0);
            }
        }
    }

    bool IsPositionOccupied(Vector3 position)
    {
        // Find all objects with the "Player" tag.
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        foreach (GameObject player in players)
        {
            // Calculate the distance between the player and the desired spawn position.
            float distance = Vector3.Distance(player.transform.position, position);

            // If the distance is smaller than a certain threshold, it's occupied.
            if (distance < 2.0f) // You can adjust this threshold.
            {
                return true;
            }
        }

        return false;
    }
}
