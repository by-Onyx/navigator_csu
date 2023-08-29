using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;

namespace Assets.Scripts.MapItems.Transitions
{
    public abstract class Transition : MapItem
    {
        public TransitionProperties TransitionProperties { get; private set; }
        public TransitionPopupProperty TransitionPopupProperty { get; protected set; }

        public Transition() : base()
        {

            TransitionProperties = new TransitionProperties();
        }
    }
}
