using Assets.Scripts.DataClasses.Properties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using DataClasses.Properties.MapItemProperties;

namespace Assets.Scripts.MapItems.Points
{
    public abstract class Point : MapItem
    {
        public PointProperty PointProperty { get; private set; }
        public PointPopupProperty PointPopupProperty { get; protected set; }

        protected Point() : base()
        {
            PointProperty = new PointProperty();
        }

        protected Point(PointProperty pointProperty) : base()
        {
            PointProperty = pointProperty;
        }
    }
}
