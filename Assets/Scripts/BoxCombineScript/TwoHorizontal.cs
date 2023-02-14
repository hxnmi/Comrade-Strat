using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHorizontal : MonoBehaviour
{
    public float combineBoxRange;
    private Transform player;
    int ID;

    void Start() 
    {
        ID = GetInstanceID();
        player = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<Transform>();
    }

    void Update() 
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if(distanceToPlayer.magnitude <= combineBoxRange && Input.GetKeyDown(KeyCode.G))
        {
            CombineBoxs();
        }
    }

    void CombineBoxs()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Instantiate(Resources.Load("WeaponPrototype"), transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("BoxHX"))
        {
            if(transform.position.y > other.transform.position.y || transform.position.y < other.transform.position.y)
            {
                if(ID < other.gameObject.GetComponent<TwoHorizontal>().ID)
                {
                    return;
                }
                transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);

                Instantiate(Resources.Load("BoxCombination/BoxUpX"), transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else
            {
                if(ID < other.gameObject.GetComponent<TwoHorizontal>().ID)
                {
                    return;
                }
                transform.position = new Vector3(transform.position.x, transform.position.y, 2f);

                Instantiate(Resources.Load("BoxCombination/BoxDown"), transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        else if(other.gameObject.CompareTag("BoxHZ"))
        {
            if(transform.position.y > other.transform.position.y || transform.position.y < other.transform.position.y)
            {
                if(ID < other.gameObject.GetComponent<TwoHorizontal>().ID)
                {
                    return;
                }
                transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);

                Instantiate(Resources.Load("BoxCombination/BoxUpZ"), transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else
            {
                if(ID < other.gameObject.GetComponent<TwoHorizontal>().ID)
                {
                    return;
                }
                transform.position = new Vector3(8f, transform.position.y, transform.position.z);

                Instantiate(Resources.Load("BoxCombination/BoxDown"), transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
