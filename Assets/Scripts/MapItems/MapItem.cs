using Assets.Scripts.DataClasses.Properties;

namespace Assets.Scripts.MapItems
{
    public abstract class MapItem
    {
        public UIProperty UIProperties { get; private set; }

        public MapItem()
        {
            this.UIProperties = new UIProperty();
        }
    }
}