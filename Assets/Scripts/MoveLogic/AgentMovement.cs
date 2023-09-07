using Assets.Scripts.MoveLogic;
using System;
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

    [SerializeField] private GameObject zeroMash;
    [SerializeField] private GameObject firstMash;
    [SerializeField] private GameObject secondMash;
    [SerializeField] private GameObject thirdMash;
    [SerializeField] private GameObject fourthMash;

    private Action action;
    private List<Tuple<int, int, GameObject>> hardcodeFloorPosition = new List<Tuple<int, int, GameObject>>();


    private bool isPathComplete = true;

    public void Init(Vector3 start, Vector3 end, Action action)
    {
        this.action = action;

        hardcodeFloorPosition.Add(Tuple.Create(0, -10, zeroMash));
        hardcodeFloorPosition.Add(Tuple.Create(1, -110, firstMash));
        hardcodeFloorPosition.Add(Tuple.Create(2, -210, secondMash));
        hardcodeFloorPosition.Add(Tuple.Create(3, -310, thirdMash));
        hardcodeFloorPosition.Add(Tuple.Create(4, -410, fourthMash));

        hardcodeFloorPosition.Where(x => x.Item1 != start.z).ToList().ForEach(x => x.Item3.gameObject.SetActive(false));

        start.z = hardcodeFloorPosition[(int)start.z].Item2;
        end.z = hardcodeFloorPosition[(int)end.z].Item2;

        print(start);
        print(end);

        point.transform.position = end;
        point.gameObject.SetActive(true);
        agent.transform.position = start;
        agent.gameObject.SetActive(true);

        agent.SetDestination(point.position);
        isPathComplete = false;

        hardcodeFloorPosition.ForEach(x => x.Item3.gameObject.SetActive(true));
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
