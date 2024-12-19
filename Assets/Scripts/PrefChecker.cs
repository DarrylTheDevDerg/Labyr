using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefChecker : MonoBehaviour
{
    public string[] prefNames;

    public bool onStart;

    // Start is called before the first frame update
    void Start()
    {
        if (onStart)
        {
            PrefValue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrefValue()
    {
        foreach (var pref in prefNames)
        {
            if (PlayerPrefs.HasKey(pref))
            {
                print($"{pref}: " + PlayerPrefs.GetFloat(pref));
            }
            else
            {
                print($"{pref} does not exist!");
            }
        }
    }
}
