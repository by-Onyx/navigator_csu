using Assets.Scripts.MoveLogic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform point;
    [SerializeField] public DrawPath drawPath;

    private bool isPathComplete;

    private void Awake()
    {
        agent.SetDestination(point.position);
    }

    private void Update()
    {
        if (agent.hasPath && !isPathComplete)
        {
            isPathComplete = true;
            drawPath.SetPath(agent.path.corners);
        }
    }
}
