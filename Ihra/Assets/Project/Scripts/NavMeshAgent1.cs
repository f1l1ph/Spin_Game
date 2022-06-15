using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgent1 : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    [SerializeField] private NavMeshAgent agent;

    int target = 0;

    void Start()
    {
        agent.destination = targets[target].position;
    }

    void FixedUpdate()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (target < targets.Length-1)
            {
                target++;
            }
            else if(target >= targets.Length-1)
            {
                target = 0;
            }

            agent.destination = targets[target].position;
        }
    }
}
