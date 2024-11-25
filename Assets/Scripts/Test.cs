using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public KeyCode key;
    public float holdDistance;
    public float holdRange;

    public Camera pov;
    public string objectTag;
    public LayerMask layer;

    private Transform held;

    // Start is called before the first frame update
    void Start()
    {
        if (pov == null)
        {
            pov = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (held != null)
            {
                DropItem();
            }
            else
            {
                AttemptGrabItem();
            }
        }

        if (held != null)
        {
            held.position = transform.position + transform.forward * holdDistance;
        }
    }

    void AttemptGrabItem()
    {
        Ray ray = new Ray(pov.transform.position, pov.transform.forward);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit, holdRange, layer))
        {
            hit.transform.SetParent(transform);
            hit.rigidbody.useGravity = false;
            held = hit.transform;

        }
    }

    void DropItem()
    {
        if (held != null)
        {
            held.SetParent(null);
            held.GetComponent<Rigidbody>().useGravity = true;
            held = null;

        }
    }

    void OnDrawGizmos()
    {
        if (pov != null)
        {
            Gizmos.color = Color.red;

            // Draw the ray
            Vector3 origin = pov.transform.position;
            Vector3 direction = pov.transform.forward;
            Gizmos.DrawLine(origin, origin + direction * holdRange);

            // Draw a sphere at the end of the ray to indicate its range
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(origin + direction * holdRange, 0.1f);
        }
    }
}
