using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour, IPointerClickHandler
{
    // [SerializeField] private Button btnPoint;
    [SerializeField] private Button btnPointLadder;
    [SerializeField] private Image pointPlace;
    [SerializeField] private Button cabinetBtn;
    [SerializeField] private Button interestBtn;
    [SerializeField] private Button ladderBtn;

    [SerializeField] private PopupPanel popupPanel;
    [SerializeField] private ButtonPoint buttonPoint;

    // private Button currentButton;
    private ButtonClicked buttonClicked = ButtonClicked.NotClicked;
    // private IOFileWork ioFile = new IOFileWork(@"\file.json");
    // private Dictionary<Button, Point> points = new Dictionary<Button, Point>();
    private List<ButtonPoint> buttonPoints = new List<ButtonPoint>();
    private Quaternion rotation = new Quaternion();

    private void Awake()
    {
        cabinetBtn.onClick.AddListener(() => { SetButtonClicked(ButtonClicked.ButtonCabinet); });
        interestBtn.onClick.AddListener(() => { SetButtonClicked(ButtonClicked.ButtonInterest); });
        ladderBtn.onClick.AddListener(() => { SetButtonClicked(ButtonClicked.ButtonLadder); });
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
        var popup = Instantiate(popupPanel, transform);
        var button = Instantiate(buttonPoint, getPosition(), rotation, transform);
        button.Init(point, popup);
        popup.Init(button.pointProperties, button);

        buttonPoints.Add(button);
    }

    public void DeletePoint()
    {
        DeletePointFromDict();
    }

    private void DeletePointFromDict()
    {
        // points.Remove(currentButton);
    }

    private void SetButtonClicked(ButtonClicked clicked)
    {
        buttonClicked = buttonClicked != clicked ? clicked : ButtonClicked.NotClicked;
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
        switch (buttonClicked)
        {
            case ButtonClicked.ButtonCabinet:
                AddPointToCanvas(new Cabinet());
                break;
            case ButtonClicked.ButtonInterest:
                AddPointToCanvas(new Interest());
                break;
            case ButtonClicked.ButtonLadder:
                AddPointToCanvas(new Ladder());
                break;
            case ButtonClicked.NotClicked:
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
