using Assets.Scripts.DataClasses;
using Assets.Scripts.MoveLogic;
using UnityEngine;
using UnityEngine.UI;

public class FloorController : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject ground_for_ground;
    [SerializeField] GameObject[] floorGrids;
    [SerializeField] Button[] floorButtons;
    private AgentMovement agent_movement;
    private FloorSelect currentFloor = FloorSelect.FirstFloor;

    private bool firstPoint;

    public void Init(AgentMovement agentMovement)
    {
        agent_movement = agentMovement;
        floorButtons[1].image.color = Color.green;
    }

    public void ShowFloor(FloorSelect floor)
    {
        firstPoint = true;
        agent_movement.drawPath.DeleteLine();
        Debug.Log($"нажата кнопка {floor}");
        currentFloor = floor;
        UpdateFloorVisibility();
        var frstcoord = GetFloorCoordinates(floor).Item1;
        var seccoord = GetFloorCoordinates(floor).Item2;
        CreatePath(frstcoord, seccoord);
        FloorSelectUse.Floor = currentFloor;
    }

    private void UpdateFloorVisibility()
    {
        for (int i = 0; i < floorGrids.Length; i++)
        {
            floorGrids[i].SetActive(true);

            if ((FloorSelect)i == currentFloor)
            {
                Color color = Color.green;
                floorButtons[i].image.color = color;
            }
            else
            {
                Color color = Color.white;
                floorButtons[i].image.color = color;
            }
        }

        ground.SetActive(currentFloor != FloorSelect.ZeroFloor);
        ground_for_ground.SetActive(currentFloor == FloorSelect.ZeroFloor);

        floorGrids[0].SetActive(currentFloor == FloorSelect.ZeroFloor);
        floorGrids[1].SetActive(currentFloor == FloorSelect.FirstFloor);
        floorGrids[2].SetActive(currentFloor == FloorSelect.SecondFloor);
        floorGrids[3].SetActive(currentFloor == FloorSelect.ThirdFloor);
        floorGrids[4].SetActive(currentFloor == FloorSelect.FourthFloor);
    }

    public void ShowFirstPath()
    {
        ShowFloor(currentFloor);
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

    private (int, int) GetFloorCoordinates(FloorSelect floor)
    {
        switch (floor)
        {
            case FloorSelect.ZeroFloor:
                return (-15, -05);
            case FloorSelect.FirstFloor:
                return (-25, -15);
            case FloorSelect.SecondFloor:
                return (-35, -25);
            case FloorSelect.ThirdFloor:
                return (-45, -35);
            case FloorSelect.FourthFloor:
                return (-55, -45);
            default:
                return (-25, -15);
        }
    }

    public void ShowZeroFloor()
    {
        ShowFloor(FloorSelect.ZeroFloor);
    }

    public void ShowFirstFloor()
    {
        ShowFloor(FloorSelect.FirstFloor);
    }

    public void ShowSecondFloor()
    {
        ShowFloor(FloorSelect.SecondFloor);
    }

    public void ShowThirdFloor()
    {
        ShowFloor(FloorSelect.ThirdFloor);
    }

    public void ShowFourthFloor()
    {
        ShowFloor(FloorSelect.FourthFloor);
    }
}