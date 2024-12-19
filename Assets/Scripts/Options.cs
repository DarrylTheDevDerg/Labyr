using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Transform player;
    public AudioMixer audioControl;
    public Slider mouseSlider, sfx, music;


    private Volume cam;
    public int lang;
    public int postProcess;
    public int fullScreen;
    private float mouseSensibility;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Volume>();

        lang = PlayerPrefs.GetInt("Idioma", 0);
        postProcess = PlayerPrefs.GetInt("Post-procesado", 0);

        float initialMouseSensibility = PlayerPrefs.GetFloat("Sensibilidad", 5f);
        float initialSFX = PlayerPrefs.GetFloat("SFX Volume", 1f);
        float initialMusic = PlayerPrefs.GetFloat("Music Volume", 1f);
        float initialRes = PlayerPrefs.GetInt("Fullscreen", 0);

        if (player != null)
        {
            player.GetComponent<MouseLook>().mouseSensitivity = initialMouseSensibility * 100;
        }

        if (mouseSlider != null)
        {
            mouseSlider.value = initialMouseSensibility;
        }

        if (sfx != null)
        {
            sfx.value = initialSFX;
        }

        if (music != null)
        {
            music.value = initialMusic;
        }

        UpdateSensibility(initialMouseSensibility);
        UpdateMusicVolume(initialMusic);
        UpdateSFXVolume(initialSFX);

        PProcessManager();
    }

    public void Update()
    {
        if (audioControl == null)
        {
            audioControl = FindObjectOfType<AudioMixer>();
        }
    }

    public void ChangeSensitivity(float value)
    {
        Debug.Log(value);
        PlayerPrefs.SetFloat("Sensibilidad", value);
    }

    public void UpdateSensibility(float newValue)
    {
        if (player != null)
        {
            player.GetComponent<MouseLook>().mouseSensitivity = newValue * 100;
        }
        
        PlayerPrefs.SetFloat("Sensibilidad", newValue);
    }

    public void UpdatePProcess()
    {
        postProcess++;

        if (postProcess > 1)
        {
            postProcess = 0;
        }

        PProcessManager();

        PlayerPrefs.SetInt("Post-procesado", postProcess);
    }

    public void ChangeSFXVolume(float value)
    {
        Debug.Log(value);
        PlayerPrefs.SetFloat("SFX Volume", value);
        UpdateSFXVolume(value);
    }

    public void UpdateSFXVolume(float newValue)
    {
        if (audioControl  != null)
        {
            audioControl.SetFloat("SFXVolume", newValue * 20f);
            print("audio var set.");
        }
    }

    public void ChangeMusicVolume(float value)
    {
        Debug.Log(value);
        PlayerPrefs.SetFloat("Music Volume", value);
        UpdateMusicVolume(value);
    }

    public void UpdateMusicVolume(float newValue)
    {
        if (audioControl != null)
        {
            audioControl.SetFloat("musicVolume", newValue * 20);
            print("audio var set.");
        }
    }

    public void PProcessManager()
    {
        if (postProcess == 1)
        {
            cam.enabled = false;
        }

        if (postProcess == 0)
        {
            cam.enabled = true;
        }
    }

    public void ChangeFullscreen()
    {
        fullScreen++;

        if (fullScreen > 1)
        {
            fullScreen = 0;
        }

        ScreenManager();

        PlayerPrefs.SetInt("Fullscreen", fullScreen);
    }

    public void ScreenManager()
    {
        if (fullScreen == 0)
        {
            Screen.fullScreen = true;
        }

        if (fullScreen == 1)
        {
            Screen.fullScreen = false;
        }
    }
}
