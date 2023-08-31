using Assets.Scripts.DataClasses.Properties;
using DataClasses.Properties.MapItemProperties;
using System.Collections.Generic;
using TMPro;
using UIClasses.MapItemButtons;
using UnityEngine;
using UnityEngine.UI;

namespace UIClasses.Popups
{
    public class PopupPointPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text header;

        [SerializeField] private TMP_InputField fieldFirst;
        [SerializeField] private TMP_InputField fieldSecond;
        [SerializeField] private TMP_InputField fieldThird;

        [SerializeField] private Button deleteBtn;

        public void Init(PointButton buttonPoint, PointPopupProperty pointPopupProperty, List<PointProperty> deletedPoints)
        {
            SetFields(buttonPoint.PointProperties);
            SetHints(pointPopupProperty);

            deleteBtn.onClick.AddListener(() => OnDeletePress(buttonPoint, deletedPoints));
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

        private void OnDeletePress(PointButton point, List<PointProperty> deletedPoints)
        {
            deletedPoints.Add(point.PointProperties);
            Destroy(point.gameObject);
            Destroy(gameObject);
        }

        public void SetPropertiesFields(PointProperty pointProperty)
        {
            pointProperty.TextFirst = fieldFirst.text;
            pointProperty.TextSecond = fieldSecond.text;
            pointProperty.TextThird = fieldThird.text;
        }
    }
}
