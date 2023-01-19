using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickNDropWeapon : MonoBehaviour
{
    public GameObject handler;
    float maxpickupdistance = 5;
    GameObject itemcurrentlyholding;
    bool isholding = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Pickup();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }
    }

    public void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(handler.transform.position, handler.transform.forward, out hit, maxpickupdistance))
        {
            if(hit.transform.tag == "Weapon")
            {
                if (isholding) Drop();

                itemcurrentlyholding = hit.transform.gameObject;

                foreach (var c in hit.transform.GetComponentsInChildren<Collider>()) if (c != null) c.enabled = false;
                foreach (var r in hit.transform.GetComponentsInChildren<Rigidbody>()) if (r != null) r.isKinematic = true;

                itemcurrentlyholding.transform.parent = transform;
                itemcurrentlyholding.transform.localPosition = Vector3.zero;
                itemcurrentlyholding.transform.localEulerAngles = Vector3.zero;

                isholding = true;
                Debug.Log("Pickup");
            }
        }
    }

    public void Drop()
    {
        itemcurrentlyholding.transform.parent = null;
        foreach (var c in itemcurrentlyholding.GetComponentsInChildren<Collider>()) if (c != null) c.enabled = true;
        foreach (var r in itemcurrentlyholding.GetComponentsInChildren<Rigidbody>()) if (r != null) r.isKinematic = false;
        isholding = false;
        RaycastHit hitDown;
        Physics.Raycast(transform.position, -Vector3.up, out hitDown);

        itemcurrentlyholding.transform.position = hitDown.point + new Vector3(transform.forward.x, 0, transform.forward.z);
        itemcurrentlyholding = null; 
    }
}
