using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCheck : MonoBehaviour
{
    public GameObject[] dropScript;

    void Start()
    {
        dropScript = GameObject.FindGameObjectsWithTag("DropArea");
    }
  
    void OnTriggerStay(Collider col) 
    {
        foreach(GameObject DA in dropScript)
        {
            if(col.gameObject.CompareTag("Player"))
            {           
                if(col.gameObject.CompareTag("BoxV"))
                {
                    DA.GetComponent<DropArea>().isTriggerArea = false;
                }
                else
                {
                    DA.GetComponent<DropArea>().isTriggerArea = true;
                }
            }
            else
            {
                DA.GetComponent<DropArea>().isTriggerArea = false;
            }
        }
    }
}
