using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public bool isTriggerArea;
    public bool isFill;

    void OnTriggerEnter(Collider col) 
    {
        if(col.gameObject.CompareTag("Weapon"))
        {
            isFill = false;
        }

        if(transform.childCount == 1)
        {
            isFill = true;
        }

        if(col.gameObject.CompareTag("Player"))
        {
            if(transform.childCount == 0 && isFill == false)
            {
                isTriggerArea = true;
            }
            else
            {
                isTriggerArea = false;        
            }
        }
    }

    void OnTriggerExit()
    {
        isTriggerArea = false;
    }
}