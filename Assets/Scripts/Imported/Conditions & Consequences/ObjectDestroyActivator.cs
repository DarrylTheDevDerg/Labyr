using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyActivator : MonoBehaviour
{
    // An array of methods or events to be activated when the object is destroyed
    public UnityEngine.Events.UnityEvent[] onDestroyActions;

    // This method is called when the object is destroyed
    private void OnDestroy()
    {
        // Loop through the onDestroyActions array and invoke each method or event
        for (int i = 0; i < onDestroyActions.Length; i++)
        {
            if (onDestroyActions[i] != null)
            {
                onDestroyActions[i].Invoke();
            }
        }
    }
}
