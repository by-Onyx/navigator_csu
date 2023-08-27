using Assets.Scripts.MoveLogic;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class agent_movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform point;
    [SerializeField] private DrawPath drawPath;

    private bool isPathComplete;

    private void Awake()
    {
        agent.SetDestination(point.position);
        drawPath.Init(agent.transform.position);
    }

    private void Update()
    {
        if (agent.hasPath && !isPathComplete)
        {
            isPathComplete = true;
            drawPath.PointToMousePos(agent.path.corners);
        }
    }
}
