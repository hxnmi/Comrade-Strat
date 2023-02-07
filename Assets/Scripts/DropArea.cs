using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public bool isTriggerArea;

    void OnTriggerStay(Collider col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {           
            if (transform.childCount == 0)
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