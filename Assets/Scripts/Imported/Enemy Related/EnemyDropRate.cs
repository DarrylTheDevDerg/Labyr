using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropRate : MonoBehaviour
{
    private float chanceTotal;
    public float chanceThreshold;
    public float divisionAmount;

    public int amountDrop;
    public GameObject[] objectsToDrop;

    public bool singularDrop;

    [SerializeField] PlayerController playerInGame;

    // Start is called before the first frame update
    void Start()
    {
        chanceTotal = Random.Range(0.0f, 100.0f) / divisionAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (chanceTotal > chanceThreshold && !singularDrop)
        {
            for (int i = 0; i < objectsToDrop.Length; i++)
            {
                for (int e = 0; e < amountDrop; e++)
                {
                    Instantiate(objectsToDrop[i]);
                }
            }
        }

        else if (chanceTotal > chanceThreshold && singularDrop)
        {
            for (int i = 0; i < objectsToDrop.Length; i++)
            {
                Instantiate(objectsToDrop[i]);
            }
        }
    }

    public void RandomizeChance()
    {
        chanceTotal = Random.Range(0.0f, 100.0f) / divisionAmount;
    }

    public void LotteryMode()
    {
        chanceTotal = Random.Range(0.0f, 100.0f) / Random.Range(0.1f, 100.0f);
    }
}
