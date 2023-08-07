using UnityEngine;

namespace Assets.Scripts.MapItems.Points
{
    public class Interest : Point
    {
        public Interest() : base()
        {
            UIProperties.Color = Color.red;
            PointProperties.PointClass = 2;
        }
    }
}
