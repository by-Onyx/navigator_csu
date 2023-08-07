using UnityEngine;
using UnityEngine.UI;

public class ButtonPoint : MonoBehaviour
{
    [SerializeField] private Button pointBtn;

    public PointProperties pointProperties { get; private set; }

    public void Init(Point point, PopupPanel popupPanel)
    {
        this.pointProperties = point.pointProperties;
        SetPointProperties(point.uiProperties);
        SetOnClick(popupPanel);
    }

    private void SetPointProperties(UIProperties properties)
    {
        var colors = pointBtn.colors;
        colors.normalColor = properties.Color;
        pointBtn.colors = colors;
    }

    private void SetOnClick(PopupPanel popupPanel)
    {
        pointBtn.onClick.AddListener(() =>
        {
            popupPanel.gameObject.SetActive(true);
            popupPanel.transform.SetAsLastSibling();
        });
    }
}
