using System;
using System.Collections;
using Assets.Scripts.DataClasses;
using Assets.Scripts.MapItems.Points;
using Assets.Scripts.MapItems.Transitions;
using Assets.Scripts.UIClasses;
using Assets.Scripts.UIClasses.Popups;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using DataClasses.Models;
using DataClasses.Models.Responses;
using DataClasses.Properties.MapItemProperties;
using IO;
using UIClasses.MapItemButtons;
using UIClasses.Popups;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;
using static DataClasses.PointMapper;

public class MainWindow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image pointPlace;

    [SerializeField] private Button closeButton;

    [SerializeField] private PopupPointPanel popupPointPanel;
    [SerializeField] private PopupTransitionPanel popupTransitionPanel;
    [SerializeField] private PopupMenuPanel popupMenuPanel;

    [SerializeField] private PointButton pointButton;
    [SerializeField] private TransitionButton transitionButton;

    [SerializeField] private AbstractDropdown pointDropdown;
    [SerializeField] private AbstractDropdown transitionDropdown;

    private IOFileWork ioFile = new(/*@"\file.json"*/);
    private List<PointButton> _pointButtons = new();
    private List<TransitionButton> transitionButtons = new();
    private Quaternion rotation = new Quaternion();
    private HttpClient _client = new() { BaseAddress = new Uri("http://localhost:8000/api") };

    private void Awake()
    {
        pointDropdown.Init();
        transitionDropdown.Init();
        closeButton.onClick.AddListener(CloseMenu);
        StartCoroutine(GetAllPoints(StartWithPoints));
    }

    private void StartWithPoints(IEnumerable<PointProperty> pointProperties)
    {
        foreach (var properties in pointProperties)
        {
            switch (properties.PointClass)
            {
                case 1:
                    AddPointToCanvas(new Cabinet());
                    break;
                case 2:
                    AddPointToCanvas(new Interest());
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
        popup.Init(button, point.PointPopupProperty);

        _pointButtons.Add(button);
    }

    private void AddTransitionToCanvas(Transition transition)
    {
        var popup = Instantiate(popupTransitionPanel, transform);
        var button = Instantiate(transitionButton, GetPosition(), rotation, transform);

        button.Init(transition, popup);
        popup.Init(button, transition.TransitionPopupProperty);

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

    /*public void SaveAll()
    {   
        List<PointProperties> pointsProperties = new List<PointProperties>();
        points.ForEach(x => pointsProperties.Add(x.pointProperties));
        ioFile.Write(pointsProperties);
    }*/

    private IEnumerator GetAllPoints(Action<IEnumerable<PointProperty>> callback)
    {
        var webRequest = PrepareGetRequest();
        yield return webRequest.SendWebRequest();
        if (!webRequest.isDone)
        {
            yield break;
        }
        
        var response =
            JsonUtility.FromJson<GetAllPointsResponse>("{\"points\":" + webRequest.downloadHandler.text + "}");
        var points = response.points.Select(Map);
        callback(points);
    }

    private UnityWebRequest PrepareGetRequest()
    {
        var request = UnityWebRequest.Get("http://195.54.14.121:8086/api/building/1/floor/1/point");
        request.SetRequestHeader("accept", "*/*");
        request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
        return request;
    }
}
