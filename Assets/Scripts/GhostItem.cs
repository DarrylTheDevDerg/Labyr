using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostItem : MonoBehaviour
{
    public float ghostTimer;
    public LayerMask collisionLayer;
    public string ghostTag;
    public LayerMask[] collisionLayers;
    public AudioSource boxFall;

    private float current = 0;
    private Rigidbody rb;
    public bool inGhost;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current > 0 && inGhost)
        {
            current -= Time.deltaTime;
            rb.detectCollisions = false;

            if (current <= 0 && inGhost)
            {
                rb.detectCollisions = true;
                inGhost = false;
                current = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        boxFall.Play();

        if (collision.collider.CompareTag(ghostTag))
        {
            current = ghostTimer;
            inGhost = true;
        }
    }
}
