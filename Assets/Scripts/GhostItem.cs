using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostItem : MonoBehaviour
{
    public float ghostTimer;
    public LayerMask ghostLayer;

    private float current;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.BoxCast(transform.position, transform.localScale / 2, transform.position.normalized, out RaycastHit hit, Quaternion.identity, ghostLayer))
        {
            current = ghostTimer;
        }

        if (current > 0)
        {
            current -= Time.deltaTime;
            rb.detectCollisions = false;

            if (current <= 0)
            {
                rb.detectCollisions = true;
                current = 0;
            }
        }
    }
}
