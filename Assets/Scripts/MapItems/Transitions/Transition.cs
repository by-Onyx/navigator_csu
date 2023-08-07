using Assets.Scripts.DataClasses.Properties.MapItemProperties;

namespace Assets.Scripts.MapItems.Transitions
{
    public abstract class Transition : MapItem
    {
        public TransitionProperties TransitionProperties { get; private set; }
        public Transition() : base()
        {
            TransitionProperties = new TransitionProperties();
        }
    }
}
