using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Cooldown")]
    public float mainCooldown;
    private float cooldown;

    [Header("Essential")]
    public ShootABullet bulletMngmnt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            bulletMngmnt.ShootNow();

            cooldown = mainCooldown;
        }
    }
}
