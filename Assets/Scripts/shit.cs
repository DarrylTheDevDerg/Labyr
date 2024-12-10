using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shit : MonoBehaviour
{
    private AudioSource aS;
    private float time, timehold = 0.5f;
    private float pitch;

    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > timehold)
        {
            pitch = Random.Range(0.65f, 3f);
            time = 0;
        }

        if (pitch > aS.pitch)
        {
            aS.pitch += Random.Range(0.01f, 0.09f);
        }

        if (pitch < aS.pitch)
        {
            aS.pitch -= Random.Range(0.01f, 0.09f);
        }
    }
}
