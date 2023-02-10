using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoVerticalBox : MonoBehaviour
{
    public float combineBoxRange;
    private Transform player;

    // private void OnTriggerStay(Collider other) 
    // {
    //     if(Input.GetKeyDown(KeyCode.G) && other.gameObject.CompareTag("Player"))
    //     {

    //     }
    // }

    void Start() 
    {
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
        transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);

        Instantiate(Resources.Load("WeaponPrototype"), transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
