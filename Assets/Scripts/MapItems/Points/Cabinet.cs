using Assets.Scripts.DataClasses.Properties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Points
{
    public class Cabinet : Point
    {
        public Cabinet() : base()
        {
            UIProperties.Color = Color.black;
            PointProperty.PointClass = 1;

            PointPopupProperty = new PointPopupProperty( "Кабинет", 
                "Введите номер кабинета",
                "Введите название кабинета", 
                "Введите заведующего за кабинетом");
        }


    }
}
