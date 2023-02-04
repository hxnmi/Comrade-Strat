using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    public float life = 3;

    void Awake() 
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject);
        Destroy(gameObject);
    }
}
