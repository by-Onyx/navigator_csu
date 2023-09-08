using Assets.Scripts.MoveLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform point;
    [SerializeField] public DrawPath drawPath;

    [SerializeField] private GameObject zeroMash;
    [SerializeField] private GameObject firstMash;
    [SerializeField] private GameObject secondMash;
    [SerializeField] private GameObject thirdMash;
    [SerializeField] private GameObject fourthMash;

    private Dictionary<int, GameObject> hardcodeFloorPosition = new Dictionary<int, GameObject>();

    private Action action;


    private bool isPathComplete = true;

    public void Init(Vector3 start, Vector3 end, Action action)
    {
        this.action = action;

        hardcodeFloorPosition.Clear();

        hardcodeFloorPosition.Add(-10, zeroMash);
        hardcodeFloorPosition.Add(-80, firstMash);
        hardcodeFloorPosition.Add(-150, secondMash);
        hardcodeFloorPosition.Add(-220, thirdMash);
        hardcodeFloorPosition.Add(-290, fourthMash);

        foreach (var pair in hardcodeFloorPosition)
        {
            if (pair.Key != start.z)
            {
                pair.Value.gameObject.SetActive(false);
                print(1);
            }
        }
        

        print(start);
        print(end);

        point.transform.position = end;
        point.gameObject.SetActive(true);
        agent.transform.position = start;
        agent.gameObject.SetActive(true);

        agent.SetDestination(point.position);
        isPathComplete = false;

        foreach (var pair in hardcodeFloorPosition)
        {
            pair.Value.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (agent.hasPath && !isPathComplete)
        {
            isPathComplete = true;
            drawPath.SetPath(agent.path.corners);
            action();
            agent.gameObject.SetActive(false);
            point.gameObject.SetActive(false);
        }
    }
}
