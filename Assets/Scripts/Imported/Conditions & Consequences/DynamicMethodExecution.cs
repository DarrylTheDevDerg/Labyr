using UnityEngine;
using System;
using System.Reflection;
using UnityEngine.Events;

public class DynamicMethodExecution : MonoBehaviour
{
    public string targetTag; // Reference to the script containing the method
    public UnityEvent[] voidsToExecute; // Name of the void method to execute

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (voidsToExecute != null)
            {
                for (int i = 0; i < voidsToExecute.Length; i++)
                {
                    voidsToExecute[i].Invoke();
                    
                }
            }
        }
    }
}
