using Assets.Scripts.DataClasses.Models.Types;

namespace Assets.Scripts.DataClasses.Properties.MapItemProperties
{
    public class TransitionProperties : MapItemProperty
    {
        public TransitionTypeModel TransitionType;

        public TransitionProperties() { }

        public TransitionProperties(float x, float y) : base(x, y) { }
    }
}