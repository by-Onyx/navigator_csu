using Assets.Scripts.DataClasses.Properties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using Assets.Scripts.MapItems.Points;
using Assets.Scripts.UIClasses.MapItemButtons;
using UnityEngine;
using UnityEngine.UI;

public class PointButton : MapItemButton
{
    public PointProperty PointProperties { get; private set; }

    public void Init(Point point, GameObject popup)
    {
        this.PointProperties = point.PointProperty;
        SetPointProperties(point.UIProperties);
        SetOnClick(popup);
    }
}
