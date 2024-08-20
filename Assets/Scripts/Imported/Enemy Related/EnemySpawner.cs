using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minRandomTime = 2f;   // Minimum time before spawning enemies
    public float maxRandomTime = 5f;   // Maximum time before spawning enemies
    public int minRandomAmount = 1;    // Minimum number of enemies to spawn
    public int maxRandomAmount = 5;    // Maximum number of enemies to spawn
    public GameObject enemySpawner;    // The spawner object
    public GameObject[] enemyPrefabs;  // Array of enemy prefabs
    public GameObject player;

    private float currentTime = 0f;   // Current time counter
    private float randomTime = 0f;    // Time for the next spawn
    private int randomAmount = 0;     // Number of enemies to spawn
    private bool triggeredRound = false; // Flag to ensure one spawn per round

    public int rounds = 5;             // Number of spawn rounds

    private Vector3 spawnerSize;       // Size of the enemy spawner
    [SerializeField] EnemyDefeatCount counter;
    [SerializeField] PlayerController playerInGame;

    private void Start()
    {
        // Initialize the first random time and amount
        randomTime = Random.Range(minRandomTime, maxRandomTime);
        randomAmount = Random.Range(minRandomAmount, maxRandomAmount);
    }

    private void Update()
    {
        // Check if there are more rounds to spawn enemies
        if (rounds > 0)
        {
            // Check if the round hasn't been triggered yet
            if (!triggeredRound)
            {
                currentTime += Time.deltaTime;

                // Check if it's time to spawn enemies
                if (currentTime > randomTime)
                {
                    // Spawn enemies
                    SpawnEnemies();

                    // Set the flag to indicate that the round has been triggered
                    triggeredRound = true;

                 
                }
            }

        }

        if (rounds <= 0)
        {
            Destroy(enemySpawner);
            Destroy(gameObject);
        }
    }

    private void SpawnEnemies()
    {
        // Get a random spawn position within the bounds of the enemy spawner
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Spawn randomAmount of enemies from the enemyPrefabs array
        for (int i = 0; i < randomAmount; i++)
        {
            int randomPrefabIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject go = Instantiate(enemyPrefabs[randomPrefabIndex], spawnPosition, Quaternion.identity);

            PlayerController pC = player.GetComponent<PlayerController>();

            AddNumberUponDestruction anud = go.GetComponent<AddNumberUponDestruction>();
            anud.counter = counter;
        }

        // Reset time and get new random values for the next round
        currentTime = 0f;
        randomTime = Random.Range(minRandomTime, maxRandomTime);
        randomAmount = Random.Range(minRandomAmount, maxRandomAmount);

        // Decrement the rounds counter
        rounds--;
        triggeredRound = false; // Reset the round trigger flag
    }

    private Vector3 CalculateSpawnerSize()
    {
        // Get the size of the enemy spawner's collider in all three dimensions
        Vector3 size = enemySpawner.GetComponent<Collider>().bounds.size;

        return size;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Calculate random X, Y, and Z positions within the bounds of the enemy spawner
        float randomX = Random.Range(-spawnerSize.x / 2f, spawnerSize.x / 2f);
        float randomY = Random.Range(-spawnerSize.y / 2f, spawnerSize.y / 2f);
        float randomZ = Random.Range(-spawnerSize.z / 2f, spawnerSize.z / 2f);

        // Get the position of the enemy spawner
        Vector3 spawnerPosition = enemySpawner.transform.position;

        // Create a vector with the random X, Y, and Z positions within the spawner's bounds
        return spawnerPosition + new Vector3(randomX, randomY, randomZ);
    }
}

