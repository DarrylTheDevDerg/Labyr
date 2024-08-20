using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("Damage Numbers")]
    public float damageMin;
    public float damageMax;
    private float damagerandomvalue;

    [Header("Enemy Detection")]
    public string targetTag = "Enemy";
    public GameObject[] enemies;
    [SerializeField] EnemyHP[] enemyHealthScripts;

    // Start is called before the first frame update
    void Start()
    {
        damagerandomvalue = Random.Range(damageMin, damageMax);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            EnemyHP enemyHP = other.gameObject.GetComponent<EnemyHP>();

           Destroy(gameObject);
           enemyHP.enemyHP -= damagerandomvalue;
        }
    }
}
