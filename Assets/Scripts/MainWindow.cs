using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Button btnPoint;
    [SerializeField] private Button btnPointLadder;
    [SerializeField] private Image pointPlace;
    [SerializeField] private Button cabinetBtn;
    [SerializeField] private Button interestBtn;
    [SerializeField] private Button ladderBtn;

    [SerializeField] private PopupLogic popupLogic;

    private Button currentButton;
    private ButtonClicked buttonClicked = ButtonClicked.NotClicked;
    //private IOFileWork ioFile = new IOFileWork(@"\file.json");
    private Dictionary<Button, Point> points = new Dictionary<Button, Point>();
    private Quaternion rotation = new Quaternion();

    private void Awake()
    {
        cabinetBtn.onClick.AddListener(() => {SetButtonClicked(ButtonClicked.ButtonCabinet);});
        interestBtn.onClick.AddListener(() => {SetButtonClicked(ButtonClicked.ButtonInterest);});
        ladderBtn.onClick.AddListener(() => {SetButtonClicked(ButtonClicked.ButtonLadder);});
        // StartWithPoints();
    }

    /*private void StartWithPoints()
    {
        var propertiesList = ioFile.Read();
        foreach (var properties in propertiesList.Points)
        {
            switch(properties.PointClass)
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

    void Update()
    {
    }

    private Vector3 getPosition()
    {
        return Input.mousePosition;
    }

    private void AddPointToCanvas(Point point)
    {
        var button = SetPointProperties(point.buttonProperties);
        button = Instantiate(button, getPosition(), rotation, this.transform);
        points.Add(button, point);
        button.onClick.AddListener(() =>
        {
            currentButton = button;
            popupLogic.EnablePopup(points[currentButton].pointProperties);
        });
    }

    private Button SetPointProperties(ButtonProperties properties)
    {
        var colors = btnPoint.colors;
        colors.normalColor = properties.Color;
        btnPoint.colors = colors;

        return btnPoint;
    }

    public void DeletePoint()
    {
        Destroy(currentButton.gameObject);
        DeletePointFromDict();
        currentButton = null;
    }

    private void DeletePointFromDict()
    {
        points.Remove(currentButton);
    }

    /*public void CabinetPress()
    {
        SetButtonClicked(ButtonClicked.ButtonCabinet);
    }

    public void InterestPress()
    {
        SetButtonClicked(ButtonClicked.ButtonInterest);
    }

    public void LadderPress()
    {
        SetButtonClicked(ButtonClicked.ButtonLadder);
    }*/

    private void SetButtonClicked(ButtonClicked clicked)
    {
        buttonClicked = buttonClicked != clicked ? clicked : ButtonClicked.NotClicked;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (!eventData.pointerCurrentRaycast.gameObject.Equals(pointPlace.gameObject))
        {
            return;
        }
        CreatePoint();
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

    /*private void OpenPopupInterest(Point point)
    {
        if(PopupInterest != null)
        {
            curPoint = point;

            var textFields = PopupInterest.GetComponentsInChildren<TMP_InputField>();
            SetTextField(textFields);

            PopupInterest.transform.SetAsLastSibling();
            PopupInterest.SetActive(true);
        }
    }

    public void SavePopupInterest()
    {
        var textFields = PopupInterest.GetComponentsInChildren<TMP_InputField>();
        SaveTextField(textFields);
        CloseAllPopups();
    }*/

    /*private void OpenPopupLadder(Point point)
    {
        if(PopupLadder != null)
        {
            curPoint = point;

            var textField = PopupLadder.GetComponentInChildren<TMP_InputField>();
            curPoint.curProperties.TextFirst = textField.text;

            var dropDowns = PopupLadder.GetComponentsInChildren<TMP_Dropdown>();
            foreach (var item in points)
            {
                if(item is Ladder)
                {
                    dropDowns.ToList().ForEach(x => x.options.Add(new TMP_Dropdown.OptionData(){text = item.curProperties.TextFirst}));
                }
            }

            PopupLadder.transform.SetAsLastSibling();
            PopupLadder.SetActive(true);
        }
    }

    public void SavePopupLadder()
    {
        var textField = PopupLadder.GetComponentInChildren<TMP_InputField>();
        curPoint.curProperties.TextFirst = textField.text;
        CloseAllPopups();
    }*/

    /*public void DeletePoint()
    {
        DestroyImmediate(curPoint.curButton);
        DeletePointFromList();
        CloseAllPopups();
    }*/

    /*private void DeletePointFromList()
    {
        points.Remove(curPoint);
    }*/

    /*private void SaveTextField(TMP_InputField[] textFields)
    {
        curPoint.pointProperties.TextFirst = textFields[0].text;
        curPoint.pointProperties.TextSecond = textFields[1].text;
        curPoint.pointProperties.TextThird = textFields[2].text;
    }

    private void SetTextField(TMP_InputField[] textFields)
    {
        textFields[0].text = curPoint.pointProperties.TextFirst;
        textFields[1].text = curPoint.pointProperties.TextSecond;
        textFields[2].text = curPoint.pointProperties.TextThird;
    }*/
}
