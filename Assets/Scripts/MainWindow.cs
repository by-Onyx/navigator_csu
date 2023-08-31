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

public class MainWindow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image pointPlace;

    [SerializeField] private Button closeButton;
    [SerializeField] private Button saveAllButton;

    [SerializeField] private PopupPointPanel popupPointPanel;
    [SerializeField] private PopupTransitionPanel popupTransitionPanel;
    [SerializeField] private PopupMenuPanel popupMenuPanel;

    [SerializeField] private PointButton pointButton;
    [SerializeField] private TransitionButton transitionButton;

    [SerializeField] private AbstractDropdown pointDropdown;
    [SerializeField] private AbstractDropdown transitionDropdown;

    private List<PointButton> pointButtons = new();
    private List<TransitionButton> transitionButtons = new();
    private List<PointProperty> deletedPoints = new();
    private List<TransitionProperties> deletedTransitions = new();
    private Quaternion rotation = new Quaternion();

    private TransitionsControllerClient transitionsControllerClient = new TransitionsControllerClient();
    private PointsControllerClient pointsControllerClient = new PointsControllerClient();

    private void Awake()
    {
        pointDropdown.Init();
        transitionDropdown.Init();
        closeButton.onClick.AddListener(CloseMenu);
        saveAllButton.onClick.AddListener(SaveAll);
        StartWithAPI();
    }

    private async void StartWithAPI()
    {
        FloorsControllerClient floorsController = new FloorsControllerClient();
        var response = await floorsController.GetAllFloors();
        if (response is null)
        {
            return;
        }
        foreach(var floor in response.Value.floors)
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
        return Input.mousePosition;
    }

    private void AddPointToCanvas(Point point)
    {
        var popup = Instantiate(popupPointPanel, transform);
        var button = Instantiate(pointButton, GetPosition(), rotation, transform);

        button.Init(point, popup);
        popup.Init(button, point.PointPopupProperty, deletedPoints);

        pointButtons.Add(button);
    }

    private void AddPointFromAPI(Point point)
    {
        var popup = Instantiate(popupPointPanel, transform);
        var button = Instantiate(pointButton, new Vector3(point.PointProperty.X, point.PointProperty.Y), rotation, transform);

        button.Init(point, popup);
        popup.Init(button, point.PointPopupProperty, deletedPoints);

        pointButtons.Add(button);
    }

    private void AddTransitionToCanvas(Transition transition)
    {
        var popup = Instantiate(popupTransitionPanel, transform);
        var button = Instantiate(transitionButton, GetPosition(), rotation, transform);

        button.Init(transition, popup);
        popup.Init(button, transition.TransitionPopupProperty, deletedTransitions);

        transitionButtons.Add(button);
    }

    private void AddTransitionFromAPI(Transition transition)
    {
        var popup = Instantiate(popupTransitionPanel, transform);
        var button = Instantiate(transitionButton, new Vector3(transition.TransitionProperties.X, transition.TransitionProperties.Y), rotation, transform);

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
        if (popupMenuPanel.IsTransitionVisible)
        {
            transitionButtons.ForEach(x => x.gameObject.SetActive(false));
        }
        else
        {
            transitionButtons.ForEach(x => x.gameObject.SetActive(true));
        }
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

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.Equals(pointPlace.gameObject))
        {
            CreatePoint();
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
                1
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
                1
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
                1,
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
                1,
                p.Id
            ));
    }

    private void DeletePoints()
    {
        deletedPoints
            .ForEach(async p => await pointsControllerClient.DeletePoint(
                1,
                1,
                p.Id
            ));
    }

    private void DeleteTransitions()
    {
        deletedTransitions
            .ForEach(async p => await transitionsControllerClient.DeleteTransition(
                1,
                1,
                p.Id
            ));
    }
}
