using Assets.Scripts.MapItems.Points;
using DataClasses.Properties.MapItemProperties;
using UIClasses.Popups;

namespace UIClasses.MapItemButtons
{
    public class PointButton : MapItemButton
    {
        public PointProperty PointProperties { get; private set; }
        private PopupPointPanel popupPointPanel;

        public void Init(Point point, PopupPointPanel popup)
        {
            PointProperties = point.PointProperty;
            PointProperties.X = gameObject.transform.position.x;
            PointProperties.Y = gameObject.transform.position.y;
            popupPointPanel = popup;
            SetPointProperties(point.UIProperties);
            SetActionOnClick(popup);
        }

        protected void SetActionOnClick(PopupPointPanel popup)
        {
            mapItemButton.onClick.AddListener(delegate
            {
                popup.gameObject.transform.SetAsLastSibling();
                popup.gameObject.SetActive(true);
            });
        }

        public void SetTextFields()
        {
            popupPointPanel.SetPropertiesFields(PointProperties);
        }
    }
}
