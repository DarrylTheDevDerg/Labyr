using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepManager : MonoBehaviour
{
    [Header("Audio Settings")]
    public float fadeDuration = 0.5f;
    public float volumeMax = 1.0f;

    [Header("Ground Detection")]
    public LayerMask groundLayer;
    public float rayDistance = 1.2f;

    public AudioClip defaultClip; // Fallback if no specific clip is found
    public AudioClip grassClip;
    public AudioClip metalClip;

    private AudioSource footstepSource;
    private bool isFadingOut = false;

    private void Awake()
    {
        footstepSource = GetComponent<AudioSource>();
        footstepSource.loop = true;
        footstepSource.volume = 0;
    }

    private void Update()
    {
        if (IsPlayerMoving())
        {
            HandleFootstepSound();
            FadeInAudio();
        }
        else
        {
            FadeOutAudio();
        }
    }

    private bool IsPlayerMoving()
    {
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }

    private void HandleFootstepSound()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance, groundLayer))
        {
            switch (hit.collider.tag)
            {
                case "Grass":
                    AssignFootstepClip(grassClip);
                    break;
                case "Metal":
                    AssignFootstepClip(metalClip);
                    break;
                default:
                    AssignFootstepClip(defaultClip);
                    break;
            }
        }
    }

    private void AssignFootstepClip(AudioClip clip)
    {
        if (footstepSource.clip != clip)
        {
            footstepSource.clip = clip;
            footstepSource.Play();
        }
    }

    private void FadeInAudio()
    {
        if (!isFadingOut && footstepSource.volume < volumeMax)
        {
            footstepSource.volume += Time.deltaTime / fadeDuration;
        }
    }

    private void FadeOutAudio()
    {
        if (footstepSource.volume > 0)
        {
            isFadingOut = true;
            footstepSource.volume -= Time.deltaTime / fadeDuration;

            if (footstepSource.volume <= 0)
            {
                footstepSource.Stop();
                footstepSource.volume = 0;
                isFadingOut = false;
            }
        }
    }
}

