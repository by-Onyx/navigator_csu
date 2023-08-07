using System;

namespace Assets.Scripts.DataClasses.Properties.MapItemProperties
{
    [Serializable]
    public class TransitionProperties : MapItemProperty
    {
        public TransitionProperties() { }

        public TransitionProperties(float x, float y) : base(x, y) { }
    }
}