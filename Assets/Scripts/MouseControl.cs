using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private enum MouseState
    {
        Lock,
        Unlock
    }

    [SerializeField] private MouseState state;

    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        if (start)
        {
            Trigger();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        switch (state)
        {
            case MouseState.Lock:
                Cursor.lockState = CursorLockMode.Locked;
                break;

            case MouseState.Unlock:
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
}
