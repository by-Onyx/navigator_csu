using System;

namespace Assets.Scripts.DataClasses.Properties.MapItemProperties
{
    [Serializable]
    public class PointProperties : MapItemProperty
    {
        public int PointClass;

        public string TextFirst;
        public string TextSecond;
        public string TextThird;

        public PointProperties() { }

        public PointProperties(float x, float y) : base(x, y) { }
    }
}
