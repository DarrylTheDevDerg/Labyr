using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AfterAnimationEnds : MonoBehaviour
{
    public Animator controller;
    public UnityEvent[] triggeredElements;

    public bool mustBeSpecific = false;
    public Animation animationNeeded;

    private void Update()
    {
        if (mustBeSpecific)
        {
            if (animationNeeded.isPlaying)
            {
                for (int i = 0; i < triggeredElements.Length; i++)
                {
                    triggeredElements[i].Invoke();
                }
            }
        }
    }


    public void TriggerEvents()
    {
        for (int i = 0; i < triggeredElements.Length; i++)
        {
            triggeredElements[i].Invoke();
        }
    }
}
