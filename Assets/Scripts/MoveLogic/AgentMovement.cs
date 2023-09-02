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

    private readonly Dictionary<int, int> hardcodeFloorPosition = new Dictionary<int, int>() 
    {
        { 0, -11 },
        { 1, -21 },
        { 2, -30 },
        { 3, -40 },
        { 4, -50 }
    };

    private bool isPathComplete = true;

    public void Init(Vector3 start, Vector3 end)
    {
        start.z = hardcodeFloorPosition[(int)start.z];
        end.z = hardcodeFloorPosition[(int)end.z];

        point.transform.position = end;
        point.gameObject.SetActive(true);
        agent.transform.position = start;
        agent.gameObject.SetActive(true);
        agent.SetDestination(point.position);

        isPathComplete = false;
    }

    private void Update()
    {
        if (agent.hasPath && !isPathComplete)
        {
            Debug.Log("aaa");
            isPathComplete = true;
            drawPath.SetPath(agent.path.corners);
        }
    }
}
