using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the Audio Source component

    public Dictionary<int, AudioClip> soundDictionary = new Dictionary<int, AudioClip>();

    // Method to add a sound to the dictionary
    public void AddSound(int soundIndex, AudioClip soundClip)
    {
        if (!soundDictionary.ContainsKey(soundIndex))
        {
            soundDictionary[soundIndex] = soundClip;
        }
    }

    // Method to play a specific sound
    public void PlaySound(int soundIndex)
    {
        if (soundDictionary.ContainsKey(soundIndex))
        {
            audioSource.clip = soundDictionary[soundIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound not found in the dictionary for index: " + soundIndex);
        }
    }
}
