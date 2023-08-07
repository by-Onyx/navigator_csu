using Assets.Scripts.DataClasses.Properties.MapItemProperties;

namespace Assets.Scripts.MapItems.Points
{
    public abstract class Point : MapItem
    {
        public PointProperties PointProperties { get; private set; }

        public Point() : base()
        {
            this.PointProperties = new PointProperties();
        }
    }
}
