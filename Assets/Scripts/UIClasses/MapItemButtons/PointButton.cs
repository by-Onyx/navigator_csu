﻿using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using Assets.Scripts.MapItems.Points;
using DataClasses.Properties.MapItemProperties;
using UIClasses.Popups;

namespace UIClasses.MapItemButtons
{
    public class PointButton : MapItemButton
    {
        public PointProperty PointProperties { get; private set; }

        public void Init(Point point, PopupPointPanel popup)
        {
            this.PointProperties = point.PointProperty;
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
    }
}
