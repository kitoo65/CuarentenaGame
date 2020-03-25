using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float deathDistance = 0.5f;
    public float distanceAway;
    public Transform thisGOTransform;
    public Transform target;
    public NavMeshAgent navMeshComp;
    public GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        target = playerGO.transform;
        navMeshComp = gameObject.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (target)
        {
            navMeshComp.SetDestination(target.position);
        }
        else
        {
            if(target = null)
            {
                target = this.gameObject.GetComponent<Transform>();
            }
            else
            {
                target = playerGO.transform;
            }
        }
        if(dist < deathDistance)
        {
            //muere el player o le sacan vida
        }
    }
}

