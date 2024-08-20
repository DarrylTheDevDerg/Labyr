using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartMethodSmth : MonoBehaviour
{
    public UnityEvent[] methods;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < methods.Length; i++) 
        {
            methods[i].Invoke();
        }
    }
}
