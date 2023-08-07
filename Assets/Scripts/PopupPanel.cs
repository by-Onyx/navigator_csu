using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField firstField;
    [SerializeField] private TMP_InputField secondField;
    [SerializeField] private TMP_InputField thirdField;
    [SerializeField] private Button deleteBtn;

    [SerializeField] private ButtonPoint buttonPoint;

    private void Awake()
    {
        deleteBtn.onClick.AddListener(() => OnDeletePress(buttonPoint));
    }

    public void Init(PointProperties pointProperties, ButtonPoint buttonPoint)
    {
        firstField.text = pointProperties.TextFirst;
        secondField.text = pointProperties.TextSecond;
        thirdField.text = pointProperties.TextThird;

        this.buttonPoint = buttonPoint;
    }

    private void OnDeletePress(ButtonPoint buttonPoint)
    {
        Destroy(buttonPoint.gameObject);
        Destroy(this.gameObject);
    }

    /*private void EnablePopup(PointProperties pointProperties)
    {
        this.pointProperties = pointProperties;
    }

    private void DisablePopup()
    {
        this.pointProperties = null;
    }

    private void SaveTextFields()
    {
        pointProperties.TextFirst = firstField.text;
        pointProperties.TextSecond = secondField.text;
        pointProperties.TextThird = thirdField.text;
    }

    private void SetTextFields()
    {
        firstField.text = pointProperties.TextFirst;
        secondField.text = pointProperties.TextSecond;
        thirdField.text = pointProperties.TextThird;
    }*/
}
