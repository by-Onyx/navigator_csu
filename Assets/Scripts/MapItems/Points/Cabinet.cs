using Assets.Scripts.DataClasses.Properties;
using DataClasses.Models;
using DataClasses.Properties.MapItemProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Points
{
    public class Cabinet : Point
    {
        public Cabinet() : base()
        {
            PointProperty.PointType = new PointTypeModel()
            {
                id = 1,
                name = "Кабинет"
            };
        }

        public Cabinet(PointProperty pointProperty) : base(pointProperty) { }

        public override void LoadSprite()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/cabinet");
        }

        public override void SetFields()
        {
            PointPopupProperty = new PointPopupProperty("Кабинет",
                "Введите номер кабинета",
                "Введите название кабинета",
                "Введите заведующего");
        }
    }
}
