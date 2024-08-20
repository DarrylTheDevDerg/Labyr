using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    public float targetTime;
    public float currentTime;
    public UnityEvent[] methods;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > targetTime) 
        {
            for (int i = 0; i < methods.Length; i++) 
            {
                methods[i].Invoke();
            }
        }
    }
}
