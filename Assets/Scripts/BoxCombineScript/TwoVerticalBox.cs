using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoVerticalBox : MonoBehaviour
{
    private void OnTriggerStay(Collider other) 
    {
        if(Input.GetKeyDown(KeyCode.G) && other.gameObject.CompareTag("Player"))
        {
            Instantiate(Resources.Load("WeaponPrototype"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
