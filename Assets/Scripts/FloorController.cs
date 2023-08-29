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

    public void ShowGroundFloor()
    {
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
        ground_for_ground.SetActive(Actives.ground_for_ground);
        Actives.floorSwitch = true;
    }
    public void ShowFirstFloor()
    {
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
    }
    public void ShowSecondFloor()
    {
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
    }
    public void ShowThirdFloor()
    {
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
    }
    public void ShowFourthFloor()
    {
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
    }
}
