using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Options : MonoBehaviour
{
    public Transform player;

    private AudioListener audioControl;
    private Volume cam;
    private int lang;
    private int postProcess;
    private float mouseSensibility;

    // Start is called before the first frame update
    void Start()
    {
        audioControl = FindObjectOfType<AudioListener>();
        cam = FindObjectOfType<Volume>();

        lang = PlayerPrefs.GetInt("Idioma", 0);
        postProcess = PlayerPrefs.GetInt("Post-procesado", 0);
        mouseSensibility = PlayerPrefs.GetFloat("Sensibilidad", 200f);

        if (postProcess > 0)
        {
            cam.enabled = false;
        }

        if (player != null)
        {
            player.GetComponent<MouseLook>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
