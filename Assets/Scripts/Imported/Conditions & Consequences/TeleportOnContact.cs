using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnContact : MonoBehaviour
{
    public float Xpos = 0f;
    public float Ypos = 0f;
    public float Zpos = 0f;

    public Vector3 teleportPosition; // The position to teleport to

    public void EditXTeleportPosition(float newX)
    {
        teleportPosition.Set(newX, Ypos, Zpos);
    }

    public void EditYTeleportPosition(float newY)
    {
        teleportPosition.Set(Xpos, newY, Zpos);
    }

    public void EditZTeleportPosition(float newZ)
    {
        teleportPosition.Set(Xpos, Ypos, newZ);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport the player
            other.transform.position = teleportPosition;
        }
    }

    

}
