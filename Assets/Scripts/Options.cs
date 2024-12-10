using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public Transform player;
    public AudioMixer audioControl;

    private Volume cam;
    private int lang;
    private int postProcess;
    private float mouseSensibility;

    // Start is called before the first frame update
    void Start()
    {
        audioControl = FindObjectOfType<AudioMixer>();
        cam = FindObjectOfType<Volume>();

        lang = PlayerPrefs.GetInt("Idioma", 0);
        postProcess = PlayerPrefs.GetInt("Post-procesado", 0);
        mouseSensibility = PlayerPrefs.GetFloat("Sensibilidad", 5f);

        if (postProcess > 0)
        {
            cam.enabled = false;
        }

        if (player != null)
        {
            player.GetComponent<MouseLook>().mouseSensitivity = mouseSensibility * 100;
        }

        if (audioControl != null)
        {
            if (!PlayerPrefs.HasKey("volumneMaster"))
            {
                audioControl.SetFloat("masterVolume", PlayerPrefs.GetFloat("volumneMaster", 100));
            }
            else
            {
                audioControl.SetFloat("masterVolume", PlayerPrefs.GetFloat("volumneMaster"));
            }
            
            if (!PlayerPrefs.HasKey("SFX Volume"))
            {
                audioControl.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFX Volume", 100));
            }
            else
            {
                audioControl.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFX Volume"));
            }

            if (!PlayerPrefs.HasKey("Music Volume"))
            {
                audioControl.SetFloat("musicVolume", PlayerPrefs.GetFloat("Music Volume", 100));
            }
            else
            {
                audioControl.SetFloat("musicVolume", PlayerPrefs.GetFloat("Music Volume"));
            }
        }
    }
}
