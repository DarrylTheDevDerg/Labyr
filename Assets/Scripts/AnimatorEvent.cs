using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{
    private Animator a;

    private void Start()
    {
        a = GetComponent<Animator>();
    }

    public void SetAnimBoolTrue(string name)
    {
        a.SetBool(name, true);
    }

    public void SetAnimBoolFalse(string name)
    {
        a.SetBool(name, false);
    }
}
