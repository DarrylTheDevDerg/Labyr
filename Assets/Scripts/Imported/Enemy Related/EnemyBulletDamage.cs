using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour
{
    [Header("Damage Numbers")]
    public float damageMin;
    public float damageMax;
    private float damagerandomvalue;

    [Header("Player Management")]
    public string targetTag = "Player";
    [SerializeField] PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
       damagerandomvalue = Random.Range(damageMin, damageMax); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            damagerandomvalue = Random.Range(damageMin, damageMax);
            other.gameObject.GetComponent<PlayerController>().TakeFlatDamage(damagerandomvalue);
            Destroy(gameObject);
        }
    }
}
