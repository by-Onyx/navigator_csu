namespace Assets.Scripts.DataClasses.Properties.MapItemProperties
{
    public abstract class MapItemProperty
    {
        public float X;
        public float Y;

        public MapItemProperty() { }

        protected MapItemProperty(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
