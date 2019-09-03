using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Despawner").transform;
        agent.SetDestination(target.position);
        //agent.steeringTarget()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
