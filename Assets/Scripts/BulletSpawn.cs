using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject bulletPrefabs;
    public float bulletSpeed = 40;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefabs, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
