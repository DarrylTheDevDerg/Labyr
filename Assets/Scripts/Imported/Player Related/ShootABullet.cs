using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootABullet : MonoBehaviour
{
    [Header("Assignated Prefabs")]
    public GameObject bulletPrefab;
    public GameObject bulletPoint;

    [Header("Bullet Management")]
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] float timeToDestroyBullet = 10;

    public void ShootNow()
    {
        GameObject instance = Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation, null);
        instance.GetComponent<Rigidbody>().AddForce(bulletPoint.transform.forward * bulletSpeed, ForceMode.Impulse);

        Destroy(instance, timeToDestroyBullet);
    }
}
