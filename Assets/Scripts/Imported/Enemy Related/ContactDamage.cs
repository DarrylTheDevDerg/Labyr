using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public string targetTag = "Player";

    public float minDamageAmount;
    public float maxDamageAmount;
    public float damageAmount;


    private void Start()
    {
        damageAmount = Random.Range(minDamageAmount, maxDamageAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            PlayerController mainScript = other.gameObject.GetComponent<PlayerController>();

            mainScript.TakeFlatDamage(damageAmount);
            damageAmount = Random.Range(minDamageAmount, maxDamageAmount);
        }
    }
}
