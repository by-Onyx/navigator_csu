using Assets.Scripts.DataClasses;
using Assets.Scripts.MapItems.Points;
using Assets.Scripts.MapItems.Transitions;
using Assets.Scripts.UIClasses;
using Assets.Scripts.UIClasses.Popups;
using ControllerClients;
using System.Collections.Generic;
using System.Linq;
using UIClasses.MapItemButtons;
using UIClasses.Popups;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static DataClasses.PointMapper;
using static Assets.Scripts.DataClasses.Models.Mappers.TransitionMapper;
using Unity.VisualScripting;
using DataClasses.Properties.MapItemProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using System.Threading;
using System.IO;

public class MainWindow : MonoBehaviour
{
    [SerializeField] private Canvas pointPlace;

    [SerializeField] private Button closeButton;
    [SerializeField] private Button saveAllButton;

    [SerializeField] private PopupPointPanel popupPointPanel;
    [SerializeField] private PopupTransitionPanel popupTransitionPanel;
    [SerializeField] private PopupMenuPanel popupMenuPanel;

    [SerializeField] private PointButton pointButton;
    [SerializeField] private TransitionButton transitionButton;

    [SerializeField] private AbstractDropdown pointDropdown;
    [SerializeField] private AbstractDropdown transitionDropdown;

    [SerializeField] private SearchSuggestion searchSuggestion;

    [SerializeField] private AgentMovement agentMovement;

    [SerializeField] private InputField pathFrom;
    [SerializeField] private InputField pathTo;

    [SerializeField] private FloorController floorController;

    private List<PointButton> pointButtons = new();
    private List<TransitionButton> transitionButtons = new();
    private List<PointProperty> deletedPoints = new();
    private List<TransitionProperties> deletedTransitions = new();
    private List<string> names = new();
    private Quaternion rotation = new Quaternion();
    private bool isAppActive = true;

    private TransitionsControllerClient transitionsControllerClient = new TransitionsControllerClient();
    private PointsControllerClient pointsControllerClient = new PointsControllerClient();

    private void Awake()
    {
        pointDropdown.Init();
        transitionDropdown.Init();
        closeButton.onClick.AddListener(CloseMenu);
        saveAllButton.onClick.AddListener(SaveAll);
        StartWithAPI();
        floorController.Init(agentMovement);
        searchSuggestion.Init(names);
    }

    private void Update()
    {
        if (isAppActive)
        {
            if(pointButtons.Count != 0)
            {
                isAppActive = false;
            }
            RenderPointOnCurrentFloor();
        }
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            CreatePoint();
            RenderPointOnCurrentFloor();
        }
    }

    private async void StartWithAPI()
    {
        FloorsControllerClient floorsController = new FloorsControllerClient();
        var response = await floorsController.GetAllFloors();
        if (response is null)
        {
            return;
        }
        foreach (var floor in response.Value.floors)
        {
            StartWithPoints(floor.id);
            StartWithTransitions(floor.id);
        }
    }

    private async void StartWithPoints(int floorId)
    {
        var response = await pointsControllerClient.GetAllPoints(1, floorId);
        if (response is null)
        {
            return;
        }
        foreach (var properties in response.Value.points.Select(MapPoint))
        {
            properties.FloorNumber = floorId;
            names.Add(properties.TextFirst);
            switch (properties.PointType.id)
            {
                case 1:
                    AddPointFromAPI(new Cabinet(properties));
                    break;
                case 2:
                    AddPointFromAPI(new Interest(properties));
                    break;
            }
        }
    }

    private async void StartWithTransitions(int floorId)
    {
        var response = await transitionsControllerClient.GetAllTransitions(1, floorId);
        if (response is null)
        {
            return;
        }
        foreach (var properties in response.Value.transitions.Select(MapTransition))
        {
            properties.FloorNumber = floorId;
            switch (properties.TransitionType.id)
            {
                case 1:
                    AddTransitionFromAPI(new Ladder(properties));
                    break;
                case 2:
                    AddTransitionFromAPI(new Elevator(properties));
                    break;
                case 3:
                    AddTransitionFromAPI(new Toilet(properties));
                    break;
            }
        }
    }

    private Vector3 GetPosition()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = -90;
        return pos;
    }

    private void AddPointToCanvas(Point point)
    {
        var popup = Instantiate(popupPointPanel, transform);
        var button = Instantiate(pointButton, GetPosition(), rotation, pointPlace.transform);

        button.Init(point, popup);
        popup.Init(button, point.PointPopupProperty, deletedPoints);

        button.PointProperties.FloorNumber = (byte)FloorSelectUse.Floor;
        print((byte)FloorSelectUse.Floor);

        pointButtons.Add(button);
    }

    private void AddPointFromAPI(Point point)
    {
        var popup = Instantiate(popupPointPanel, transform);
        var button = Instantiate(pointButton, new Vector3(point.PointProperty.X, point.PointProperty.Y, -90), rotation, pointPlace.transform);

        button.Init(point, popup);
        popup.Init(button, point.PointPopupProperty, deletedPoints);

        pointButtons.Add(button);
    }

    private void AddTransitionToCanvas(Transition transition)
    {
        var popup = Instantiate(popupTransitionPanel, transform);
        var button = Instantiate(transitionButton, GetPosition(), rotation, pointPlace.transform);

        button.Init(transition, popup);
        popup.Init(button, transition.TransitionPopupProperty, deletedTransitions);

        button.TransitionProperties.FloorNumber = (byte)FloorSelectUse.Floor;

        transitionButtons.Add(button);
    }

    private void AddTransitionFromAPI(Transition transition)
    {
        var popup = Instantiate(popupTransitionPanel, transform);
        var button = Instantiate(transitionButton, new Vector3(transition.TransitionProperties.X, transition.TransitionProperties.Y, -90), rotation, pointPlace.transform);

        button.Init(transition, popup);
        popup.Init(button, transition.TransitionPopupProperty, deletedTransitions);

        transitionButtons.Add(button);
    }

    private void CloseMenu()
    {
        TransitionVisible();
        Disabled();
    }

    private void TransitionVisible()
    {
        transitionButtons.ForEach(x => x.gameObject.SetActive(!popupMenuPanel.IsTransitionVisible));
    }

    public void RenderPointOnCurrentFloor()
    {
        pointButtons.ForEach(x => x.gameObject.SetActive(false));
        transitionButtons.ForEach(x => x.gameObject.SetActive(false));
        var floor = (byte)FloorSelectUse.Floor;

        pointButtons
            .Where(x => x.PointProperties.FloorNumber == floor)
            .ToList()
            .ForEach(x => x.gameObject.SetActive(true));
        transitionButtons
            .Where(x => x.TransitionProperties.FloorNumber == floor)
            .ToList()
            .ForEach(x => x.gameObject.SetActive(true));
    }

    private void Disabled()
    {
        if (popupMenuPanel.IsDisabled)
        {

        }
        else
        {

        }
    }

    private void CreatePoint()
    {
        switch (OptionSelectUse.Option)
        {
            case OptionSelect.CabinetSelected:
                AddPointToCanvas(new Cabinet());
                break;
            case OptionSelect.InterestSelected:
                AddPointToCanvas(new Interest());
                break;
            case OptionSelect.LadderSelected:
                AddTransitionToCanvas(new Ladder());
                break;
            case OptionSelect.ElevatorSelected:
                AddTransitionToCanvas(new Elevator());
                break;
            case OptionSelect.ToiletSelected:
                AddTransitionToCanvas(new Toilet());
                break;
            case OptionSelect.NothingSelected:
                break;
        }
    }

    public void DrawPath()
    {
        if (string.IsNullOrEmpty(pathFrom.text) || string.IsNullOrEmpty(pathTo.text)) return;

        var point = pointButtons
            .Where(x => x.PointProperties.TextFirst == pathFrom.text)
            .Select(x => x.PointProperties)
            .FirstOrDefault();
        Vector3 start = new Vector3(point.X, point.Y, point.FloorNumber);

        point = pointButtons
            .Where(x => x.PointProperties.TextFirst == pathTo.text)
            .Select(x => x.PointProperties)
            .FirstOrDefault();
        Vector3 end = new Vector3(point.X, point.Y, point.FloorNumber);

        agentMovement.Init(start, end);
    }

    private void SaveAll()
    {
        Debug.Log("Yaaaaay");
        pointButtons.ForEach(x => x.SetTextFields());
        pointButtons.Select(x => x.gameObject != null);
        transitionButtons.Select(x => x.gameObject != null);
        DeletePoints();
        DeleteTransitions();
        AddNewPointsToAPI();
        AddNewTransitionsToAPI();
        UpdatePoints();
        UpdateTransitions();
    }

    private void AddNewPointsToAPI()
    {
        pointButtons
            .Select(x => x.PointProperties)
            .ToList()
            .ForEach(async p => await pointsControllerClient.CreatePoint(
                new DataClasses.Models.Requests.CreatePointRequest
                {
                    id = p.Id,
                    pointType = p.PointType,
                    firstField = p.TextFirst,
                    secondField = p.TextSecond,
                    thirdField = p.TextThird,
                    x = p.X,
                    y = p.Y
                },
                1,
                p.FloorNumber
            ));
    }

    private void AddNewTransitionsToAPI()
    {
        transitionButtons
            .Select(x => x.TransitionProperties)
            .ToList()
            .ForEach(async p => await transitionsControllerClient.CreateTransition(
                new DataClasses.Models.Requests.CreateTransitionRequest
                {
                    id = p.Id,
                    transitionType = p.TransitionType,
                    x = p.X,
                    y = p.Y
                },
                1,
                p.FloorNumber
            ));
    }

    private void UpdatePoints()
    {
        pointButtons
            .Select(x => x.PointProperties)
            .ToList()
            .ForEach(async p => await pointsControllerClient.UpdatePoint(
                new DataClasses.Models.Requests.UpdatePointRequest
                {
                    id = p.Id,
                    pointType = p.PointType,
                    firstField = p.TextFirst,
                    secondField = p.TextSecond,
                    thirdField = p.TextThird,
                    x = p.X,
                    y = p.Y
                },
                1,
                p.FloorNumber,
                p.Id
            ));
    }

    private void UpdateTransitions()
    {
        transitionButtons
            .Select(x => x.TransitionProperties)
            .ToList()
            .ForEach(async p => await transitionsControllerClient.UpdateTransition(
                new DataClasses.Models.Requests.UpdateTransitionRequest
                {
                    id = p.Id,
                    transitionType = p.TransitionType,
                    x = p.X,
                    y = p.Y
                },
                1,
                p.FloorNumber,
                p.Id
            ));
    }

    private void DeletePoints()
    {
        deletedPoints
            .ForEach(async p => await pointsControllerClient.DeletePoint(
                1,
                p.FloorNumber,
                p.Id
            ));
    }

    private void DeleteTransitions()
    {
        deletedTransitions
            .ForEach(async p => await transitionsControllerClient.DeleteTransition(
                1,
                p.FloorNumber,
                p.Id
            ));
    }
}