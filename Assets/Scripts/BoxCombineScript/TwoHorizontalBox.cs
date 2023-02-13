using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHorizontalBox : MonoBehaviour
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
            if(ID < other.gameObject.GetComponent<TwoHorizontalBox>().ID)
            {
                return;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Instantiate(Resources.Load("BoxCombination/BoxDown"), transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }    
}
