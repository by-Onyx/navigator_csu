using Assets.Scripts.DataClasses.Properties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using DataClasses.Properties.MapItemProperties;

namespace Assets.Scripts.MapItems.Points
{
    public abstract class Point : MapItem
    {
        public PointProperty PointProperty { get; private set; }
        public PointPopupProperty PointPopupProperty { get; protected set; }

        public Point() : base()
        {
            PointProperty = new PointProperty();
        }
    }
}
