using Assets.Scripts.DataClasses;
using Assets.Scripts.MoveLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorController : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject ground_for_ground;
    [SerializeField] GameObject ground_floor_grid;
    [SerializeField] GameObject first_floor_grid;
    [SerializeField] GameObject second_floor_grid;
    [SerializeField] GameObject third_floor_grid;
    [SerializeField] GameObject fourth_floor_grid;
    private AgentMovement agent_movement;

    private bool firstPoint;

    public void Init(AgentMovement agentMovement)
    {
        this.agent_movement = agentMovement;
    }

    public void ShowGroundFloor()
    {
        firstPoint = true;
        agent_movement.drawPath.DeleteLine();
        print("нажата кнопка 0");
        Actives.groundFloor = true;
        Actives.firstFloor = false;
        Actives.secondFloor = false;
        Actives.thirdFloor = false;
        Actives.fourthFloor = false;
        Actives.ground = false;
        Actives.ground_for_ground = true;
        ground_floor_grid.SetActive(Actives.groundFloor);
        first_floor_grid.SetActive(Actives.firstFloor);
        second_floor_grid.SetActive(Actives.secondFloor);
        third_floor_grid.SetActive(Actives.thirdFloor);
        fourth_floor_grid.SetActive(Actives.fourthFloor);
        ground.SetActive(Actives.ground);
        ground_for_ground.SetActive(Actives.ground);
        Actives.floorSwitch = true;
        CreatePath(-15, -05);

        FloorSelectUse.Floor = FloorSelect.ZeroFloor;
    }
    public void ShowFirstFloor()
    {
        firstPoint = true;
        agent_movement.drawPath.DeleteLine();
        print("нажата кнопка 1");
        Actives.groundFloor = false;
        Actives.firstFloor = true;
        Actives.secondFloor = false;
        Actives.thirdFloor = false;
        Actives.fourthFloor = false;
        Actives.ground = true;
        Actives.ground_for_ground = false;
        ground_floor_grid.SetActive(Actives.groundFloor);
        first_floor_grid.SetActive(Actives.firstFloor);
        second_floor_grid.SetActive(Actives.secondFloor);
        third_floor_grid.SetActive(Actives.thirdFloor);
        fourth_floor_grid.SetActive(Actives.fourthFloor);
        ground.SetActive(Actives.ground);
        ground_for_ground.SetActive(Actives.ground_for_ground);
        Actives.floorSwitch = true;
        CreatePath(-25, -15);

        FloorSelectUse.Floor = FloorSelect.FirstFloor;
    }
    public void ShowSecondFloor()
    {
        firstPoint = true;
        agent_movement.drawPath.DeleteLine();
        print("нажата кнопка 2");
        Actives.groundFloor = false;
        Actives.firstFloor = false;
        Actives.secondFloor = true;
        Actives.thirdFloor = false;
        Actives.fourthFloor = false;
        Actives.ground = true;
        Actives.ground_for_ground = false;
        ground_floor_grid.SetActive(Actives.groundFloor);
        first_floor_grid.SetActive(Actives.firstFloor);
        second_floor_grid.SetActive(Actives.secondFloor);
        third_floor_grid.SetActive(Actives.thirdFloor);
        fourth_floor_grid.SetActive(Actives.fourthFloor);
        ground.SetActive(Actives.ground);
        ground_for_ground.SetActive(Actives.ground_for_ground);
        Actives.floorSwitch = true;
        CreatePath(-35, -25);

        FloorSelectUse.Floor = FloorSelect.SecondFloor;
    }
    public void ShowThirdFloor()
    {
        firstPoint = true;
        agent_movement.drawPath.DeleteLine();
        print("нажата кнопка 3");
        Actives.groundFloor = false;
        Actives.firstFloor = false;
        Actives.secondFloor = false;
        Actives.thirdFloor = true;
        Actives.fourthFloor = false;
        Actives.ground = true;
        Actives.ground_for_ground = false;
        ground_floor_grid.SetActive(Actives.groundFloor);
        first_floor_grid.SetActive(Actives.firstFloor);
        second_floor_grid.SetActive(Actives.secondFloor);
        third_floor_grid.SetActive(Actives.thirdFloor);
        fourth_floor_grid.SetActive(Actives.fourthFloor);
        ground.SetActive(Actives.ground);
        ground_for_ground.SetActive(Actives.ground_for_ground);
        Actives.floorSwitch = true;
        CreatePath(-45, -35);

        FloorSelectUse.Floor = FloorSelect.ThirdFloor;
    }
    public void ShowFourthFloor()
    {
        firstPoint = true;
        agent_movement.drawPath.DeleteLine();
        print("нажата кнопка 4");
        Actives.groundFloor = false;
        Actives.firstFloor = false;
        Actives.secondFloor = false;
        Actives.thirdFloor = false;
        Actives.fourthFloor = true;
        Actives.ground = true;
        Actives.ground_for_ground = false;
        ground_floor_grid.SetActive(Actives.groundFloor);
        first_floor_grid.SetActive(Actives.firstFloor);
        second_floor_grid.SetActive(Actives.secondFloor);
        third_floor_grid.SetActive(Actives.thirdFloor);
        fourth_floor_grid.SetActive(Actives.fourthFloor);
        ground.SetActive(Actives.ground);
        ground_for_ground.SetActive(Actives.ground_for_ground);
        Actives.floorSwitch = true;
        CreatePath(-55, -45);

        FloorSelectUse.Floor = FloorSelect.FourthFloor;
    }

    private void CreatePath(int startZ, int endZ)
    {
        foreach (var line in DrawPath.LineSegments)
        {
            if (line.Key > startZ && line.Key < endZ)
            {
                foreach (var point in line.Value)
                {
                    if (firstPoint)
                    {
                        agent_movement.drawPath.Init(point);
                        firstPoint = false;
                    }
                    else
                    {
                        agent_movement.drawPath.AddAPoint(point);
                    }
                }
            }
        }
    }
}
