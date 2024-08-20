using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class UpdateSetAnim : MonoBehaviour
{
    public string parameterName;
    public int parameterNum;
    public Animator animator;

    public bool isInteger;
    public bool isTrigger;

    void Update()
    {
        if (isInteger)
        {
            animator.SetInteger(parameterName, parameterNum);
        }

        if (isTrigger)
        {
            if (animator.GetBool(parameterName) == false)
            {
                animator.SetTrigger(parameterName);
            }

            else
            {
                animator.ResetTrigger(parameterName);
            }
        }
    }
}
