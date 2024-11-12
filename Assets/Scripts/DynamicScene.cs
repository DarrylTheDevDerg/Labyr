using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DynamicScene : MonoBehaviour
{
    // Nombre de la escena a la que se va a cargar
    public string targetScene;
    public bool isCollision, isKey, isTimed;
    public float timel;

    public UnityEvent stuff;

    public KeyCode key;

    private float time;

    void Update()
    {
        if (isTimed)
        {
            time += Time.deltaTime;

            if (time > timel)
            {
                DoStuff();
            }
        }

        if (Input.GetKeyDown(key) && isKey)
        {
            DoStuff();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollision)
        {
            DoStuff();
        }
    }

    void DoStuff()
    {
        if (stuff != null)
        {
            stuff.Invoke();
        }

        SceneManager.LoadScene(targetScene);
    }
}
