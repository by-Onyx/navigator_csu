using Assets.Scripts.DataClasses.Properties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupPointPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text Header;

    [SerializeField] private TMP_InputField FirstField;
    [SerializeField] private TMP_InputField SecondField;
    [SerializeField] private TMP_InputField ThirdField;

    /*[SerializeField] private Text FirstHint;
    [SerializeField] private Text SecondHint;
    [SerializeField] private Text ThirdHint;*/

    [SerializeField] private Button deleteBtn;

    public void Init(PointButton buttonPoint, PointPopupProperty pointPopupProperty)
    {
        SetFields(buttonPoint.PointProperties);
        // SetHints(pointPopupProperty);
        deleteBtn.onClick.AddListener(() => OnDeletePress(buttonPoint.gameObject));
    }

    private void SetFields(PointProperty property)
    {
        FirstField.text = property.TextFirst;
        SecondField.text = property.TextSecond;
        ThirdField.text = property.TextThird;
    }

   /* private void SetHints(PointPopupProperty property)
    {
        Header.text = property.Header;
        FirstHint.text = property.FieldHintFirst;
        SecondHint.text = property.FieldHintSecond;
        ThirdHint.text = property.FieldHintThird;
    }*/

    private void OnDeletePress(GameObject point)
    {
        Destroy(point);
        Destroy(this.gameObject);
    }
}
