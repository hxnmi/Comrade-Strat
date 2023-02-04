using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickNDropWeapon : MonoBehaviour
{
    // public ProjectileGun gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, tppCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        if(!equipped)
        {
            // gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if(equipped)
        {
            // gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }

        if(equipped && Input.GetKeyDown(KeyCode.F))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;

        GetComponent<BulletSpawn>().enabled = true;
        // gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        // rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(tppCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(tppCam.up * dropUpwardForce, ForceMode.Impulse);

        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        GetComponent<BulletSpawn>().enabled = false;
        // gunScript.enabled = false;
    }
}
