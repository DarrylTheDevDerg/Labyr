using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnyKeyScript : MonoBehaviour
{

    public UnityEvent[] scriptsToRun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < scriptsToRun.Length; i++)
            {
                scriptsToRun[i].Invoke();
            }
        }
    }
}
