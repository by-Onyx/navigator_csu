using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorController : MonoBehaviour
{
    [SerializeField] GameObject ground_floor_grid;
    [SerializeField] GameObject first_floor_grid;
    [SerializeField] GameObject second_floor_grid;
    [SerializeField] GameObject third_floor_grid;
    [SerializeField] GameObject fourth_floor_grid;

    public void ShowFirstFloor()
    {
        Actives.firstFloor = true;
        Actives.secondFloor = false;
        first_floor_grid.SetActive(Actives.firstFloor);
        second_floor_grid.SetActive(Actives.secondFloor);
        Actives.floorSwitch = true;
    }

    public void ShowSecondFloor()
    {
        Actives.firstFloor = false;
        Actives.secondFloor = true;
        first_floor_grid.SetActive(Actives.firstFloor);
        second_floor_grid.SetActive(Actives.secondFloor);
        Actives.floorSwitch = true;
    }
}
