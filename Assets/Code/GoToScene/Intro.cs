using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Nombre de la escena a la que se va a cargar
    public string targetScene;

    void Update()
    {
        // Detecta si se presiona la tecla "Enter" o "Return"
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Carga la escena especificada
            SceneManager.LoadScene(targetScene);
        }
    }
}
