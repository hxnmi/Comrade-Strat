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

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Box"))
        {
            if(transform.position.x > other.transform.position.x || transform.position.x < other.transform.position.x)
            {
                if(ID < other.gameObject.GetComponent<BoxCombine>().ID)
                {
                    return;
                }
                transform.position = new Vector3(8f, transform.position.y, transform.position.z);

                Instantiate(Resources.Load("BoxCombination/BoxHorizontalX"), transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else if(transform.position.z > other.transform.position.z || transform.position.z < other.transform.position.z)
            {
                if(ID < other.gameObject.GetComponent<BoxCombine>().ID)
                {
                    return;
                }
                transform.position = new Vector3(transform.position.x, transform.position.y, 2f);
                Vector3 Rot = new Vector3(0, 90, 0);
                Quaternion newRotation = Quaternion.Euler(Rot);

                Instantiate(Resources.Load("BoxCombination/BoxHorizontalZ"), transform.position, newRotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else if(transform.position.y > other.transform.position.y || transform.position.y < other.transform.position.y)
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
}