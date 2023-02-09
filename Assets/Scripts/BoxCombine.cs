using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCombine : MonoBehaviour
{
    int ID;

    void Start() 
    {
        ID = GetInstanceID();
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("Box"))
        {
            if(ID < other.gameObject.GetComponent<BoxCombine>().ID)
            {
                return;
            }
            transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);

            Instantiate(Resources.Load("BoxCombination/BoxVectical"), transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}