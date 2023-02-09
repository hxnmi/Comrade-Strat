using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    private Transform enemyPos;
    private float dist;
    public float enemyRange;

    void Start() 
    {
        // GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        
        // foreach (GameObject enem in enemy)
        // {
        //     enemyPos = enem.transform;
        // }
    }

    void Update()
    {
        GameObject enemyName = FindClosestEnemy();
        
        if(FindClosestEnemy() != null)
        {
            enemyPos = enemyName.transform;
            dist = Vector3.Distance(enemyPos.position, transform.position);
            if(dist <= enemyRange)
            {
                transform.LookAt(enemyPos);

                if(transform.localEulerAngles.z < 90 && transform.localEulerAngles.z > -90)
                {
                    transform.localEulerAngles = new Vector3(270, 0, 0);
                }
            }
        }
        else
        {
            transform.localEulerAngles = new Vector3(270, 0, 0);
        }
    }

    public GameObject FindClosestEnemy() 
    {
        float min = 2;
        float max = 20;

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        
        min = min * min;
        max = max * max;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance >= min && curDistance <= max)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


}
