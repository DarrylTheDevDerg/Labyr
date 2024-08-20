using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class StartSetAnim : MonoBehaviour
{
    public string parameterName;
    public int parameterNum;
    public Animator animator;

    public bool isInteger;
    public bool isTrigger;

    // Start is called before the first frame update
    void Start()
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

    public void ResetParameters()
    {
        if (isInteger)
        {
            animator.SetInteger(parameterName, 0);

        }

        if (isTrigger)
        {
            if (animator.GetBool(parameterName) == true)
            {
                animator.ResetTrigger(parameterName);
            }
        }
    }
}
