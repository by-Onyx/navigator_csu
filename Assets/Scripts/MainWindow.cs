using Assets.Scripts.DataClasses;
using Assets.Scripts.MapItems.Points;
using Assets.Scripts.MapItems.Transitions;
using Assets.Scripts.UIClasses;
using Assets.Scripts.UIClasses.MapItemButtons;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image pointPlace;

    [SerializeField] private PopupPointPanel popupPointPanel;

    [SerializeField] private PointButton buttonPoint;
    [SerializeField] private TransitionButton transitionButton;

    [SerializeField] private AbstractDropdown pointDropdown;
    [SerializeField] private AbstractDropdown transitionDropdown;

    // private Button currentButton;
    // private IOFileWork ioFile = new IOFileWork(@"\file.json");
    // private Dictionary<Button, Point> points = new Dictionary<Button, Point>();
    private List<PointButton> pointButtons = new List<PointButton>();
    private List<TransitionButton> transitionButtons = new List<TransitionButton>();
    private Quaternion rotation = new Quaternion();

    private void Awake()
    {
        pointDropdown.Init();
        transitionDropdown.Init();
        /*cabinetBtn.onClick.AddListener(() => { SetButtonClicked(OptionSelect.Cabinetselected); });
        interestBtn.onClick.AddListener(() => { SetButtonClicked(OptionSelect.InterestSelected); });
        ladderBtn.onClick.AddListener(() => { SetButtonClicked(OptionSelect.LadderSelected); });*/
        // StartWithPoints();
    }

    /*private void StartWithPoints()
    {
        var propertiesList = ioFile.Read();
        foreach (var properties in propertiesList.Points)
        {
            switch (properties.PointClass)
            {
                case 1:
                    AddPointToCanvas(new Cabinet(properties, OpenPopupCabinet));
                    break;
                case 2:
                    AddPointToCanvas(new Interest(properties, OpenPopupCabinet));
                    break;
                case 3:
                    AddPointToCanvas(new Ladder(properties, OpenPopupCabinet));
                    break;
                default:
                    break;

            }
        }
    }*/

    private Vector3 getPosition()
    {
        return Input.mousePosition;
    }

    private void AddPointToCanvas(Point point)
    {
        var popup = Instantiate(popupPointPanel, transform);
        var button = Instantiate(buttonPoint, getPosition(), rotation, transform);
        button.Init(point, popup.gameObject);
        popup.Init(button, point.PointPopupProperty);

        pointButtons.Add(button);
    }

    private void AddTransitionToCanvas(Transition transition)
    {
        var button = Instantiate(transitionButton, getPosition(), rotation, transform);

        transitionButtons.Add(button);
    }

    /*public void DeletePoint()
    {
        DeletePointFromDict();
    }

    private void DeletePointFromDict()
    {
        // points.Remove(currentButton);
    }

    private void SetButtonClicked(OptionSelect clicked)
    {
        buttonClicked = buttonClicked != clicked ? clicked : OptionSelect.NothingSelected;
    }*/

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
            case OptionSelect.Cabinetselected:
                AddPointToCanvas(new Cabinet());
                break;
            case OptionSelect.InterestSelected:
                AddPointToCanvas(new Interest());
                break;
            case OptionSelect.LadderSelected:
                AddTransitionToCanvas(new Ladder());
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
}
