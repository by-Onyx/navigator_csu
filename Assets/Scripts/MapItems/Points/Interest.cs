using Assets.Scripts.DataClasses.Properties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Points
{
    public class Interest : Point
    {
        public Interest() : base()
        {
            UIProperties.Color = Color.red;
            PointProperty.PointClass = 2;

            PointPopupProperty = new PointPopupProperty("Точка интереса",
                "Введите название точки",
                "Введите краткое описание",
                "Введите доп. названия");
        }
    }
}
