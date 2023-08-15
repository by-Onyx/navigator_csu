using Assets.Scripts.DataClasses.Properties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupPointPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text header;

    [SerializeField] private TMP_InputField fieldFirst;
    [SerializeField] private TMP_InputField fieldSecond;
    [SerializeField] private TMP_InputField fieldThird;

    [SerializeField] private Button deleteBtn;

    public void Init(PointButton buttonPoint, PointPopupProperty pointPopupProperty)
    {
        SetFields(buttonPoint.PointProperties);
        SetHints(pointPopupProperty);
        deleteBtn.onClick.AddListener(() => OnDeletePress(buttonPoint));
    }

    private void SetFields(PointProperty property)
    {
        fieldFirst.text = property.TextFirst;
        fieldSecond.text = property.TextSecond;
        fieldThird.text = property.TextThird;
    }

    private void SetHints(PointPopupProperty property)
    {
        header.text = property.Header;

        fieldFirst.placeholder.GetComponent<TextMeshProUGUI>().text = property.FieldHintFirst;
        fieldSecond.placeholder.GetComponent<TextMeshProUGUI>().text = property.FieldHintSecond;
        fieldThird.placeholder.GetComponent<TextMeshProUGUI>().text = property.FieldHintThird;
    }

    private void OnDeletePress(PointButton point)
    {
        Destroy(point.gameObject);
        Destroy(this.gameObject);
    }
}
