using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agent_movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform point;

    void Start()
    {
        //agent.updateUpAxis = false;
        //agent.updateRotation = false;
        print(agent.remainingDistance);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(point.position);
    }
}
