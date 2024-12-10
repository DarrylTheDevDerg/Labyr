using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AudioClipItem
{
    public string tagNeeded;
    public AudioClip audioClip;
}

public class FootstepNoise : MonoBehaviour
{
    public LayerMask groundLayers;
    public float raycastRange;
    [Range(0f, 0.1f)]
    public float threshold;
    public AudioClip defaultClip;

    [Range(0f, 1f)]
    public float maxVolume;

    [SerializeField]
    private List<AudioClipItem> audioClips = new List<AudioClipItem>();

    public AudioSource audioSource;
    public bool isMoving = false;

    public Rigidbody rb;

    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float savedVolume = audioSource.volume;

        SoundCheck();
        CheckPlayer();

        if (!isMoving && audioSource.volume > 0 && Time.timeScale > 0f)
        {
            audioSource.volume -= 0.05f;
        }

        if (isMoving && audioSource.volume < maxVolume && Time.timeScale > 0f)
        {
            audioSource.volume += 0.05f;
        }

        if (Time.timeScale == 0f)
        {
            audioSource.mute = true;
        }

        if (Time.timeScale > 0f)
        {
            audioSource.mute = false;
        }
    }

    void CheckUnderneathPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastRange, groundLayers))
        {
            SoundManager(hit.collider.tag);
        }
    }


    void CheckPlayer()
    {
        Vector3 positionDelta = transform.position - lastPosition;

        if (positionDelta.magnitude > threshold)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastPosition = transform.position; // Update last position for next frame
    }

    void SoundManager(string tag)
    {
        foreach (AudioClipItem item in audioClips)
        {
            if (item.audioClip != audioSource.clip)
            {
                if (item.tagNeeded == tag)
                {
                    audioSource.clip = item.audioClip;
                    audioSource.time = 0;
                    audioSource.Play();

                    break;
                }


                if (item.tagNeeded == null)
                {
                    audioSource.clip = defaultClip;
                    audioSource.time = 0;
                    audioSource.Play();


                    break;
                }
            }
        }
    }

    bool SoundCheck()
    {
        bool value = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastRange, groundLayers))
        {
            string surfaceTag = hit.collider.tag;
            string formerTag = "";

            if (!formerTag.Equals(surfaceTag))
            {
                SoundManager(surfaceTag);
                value = true;
            }
            else
            {
                value = false;
            }

        }

        return value;
    }
}
