using Assets.Scripts.DataClasses.Properties;
using DataClasses.Models;
using DataClasses.Properties.MapItemProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Points
{
    public class Interest : Point
    {
        public Interest() : base()
        {
            PointProperty.PointType = new PointTypeModel()
            {
                id = 2,
                name = "Точка интереса"
            };
        }

        public Interest(PointProperty pointProperty) : base(pointProperty) { }

        public override void LoadSprite()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/exclam_sign");
        }

        public override void SetFields()
        {
            PointPopupProperty = new PointPopupProperty("Точка интереса",
                "Введите название точки",
                "Введите краткое описание",
                "Введите доп. названия");
        }
    }
}
