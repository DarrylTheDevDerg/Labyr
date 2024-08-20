using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float selfDestructDelay = 3f;   // Time delay before self-destruction

    private void Start()
    {
        // Call the SelfDestruct method after the specified delay
        Invoke("SelfDestructObject", selfDestructDelay);
    }

    private void SelfDestructObject()
    {
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
