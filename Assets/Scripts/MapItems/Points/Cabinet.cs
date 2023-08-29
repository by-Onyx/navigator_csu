using Assets.Scripts.DataClasses.Properties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Points
{
    public class Cabinet : Point
    {
        public Cabinet() : base()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/cabinet");

            PointProperty.PointClass = 1;

            PointPopupProperty = new PointPopupProperty("Кабинет",
                "Введите номер кабинета",
                "Введите название кабинета",
                "Введите заведующего");
        }


    }
}
