namespace Assets.Scripts.DataClasses.Properties.MapItemProperties
{
    public abstract class MapItemProperty
    {
        public int Id;

        public float X;
        public float Y;

        public int FloorNumber;

        public MapItemProperty() { }

        protected MapItemProperty(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
