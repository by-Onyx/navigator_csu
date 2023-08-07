using UnityEngine;

namespace Assets.Scripts.MapItems.Points
{
    public class Cabinet : Point
    {
        public Cabinet() : base()
        {
            UIProperties.Color = Color.black;
            PointProperties.PointClass = 1;
        }
    }
}
