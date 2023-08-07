using Assets.Scripts.DataClasses.Properties;

namespace Assets.Scripts.MapItems
{
    public abstract class MapItem
    {
        public UIProperties UIProperties { get; private set; }

        public MapItem()
        {
            this.UIProperties = new UIProperties();
        }
    }
}
