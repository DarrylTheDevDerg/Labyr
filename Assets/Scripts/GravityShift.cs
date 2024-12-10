using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShift : MonoBehaviour
{
    public bool invertGravity;
    public float gravity;

    public bool onStart;

    // Start is called before the first frame update
    void Start()
    {
        if (onStart)
        {
            NewGravity();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewGravity()
    {
        Physics.gravity = new Vector3(0, gravity);

        if (invertGravity)
        {
            Physics.gravity = Physics.gravity * -1;
        }
    }
}
