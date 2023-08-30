using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class Ladder : Transition
    {
        public Ladder() : base()
        {
            TransitionProperties.TransitionClass = 1;
        }

        public Ladder(TransitionProperties transitionProperties) : base(transitionProperties) { }

        public override void LoadSprite()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/ladder1");
        }

        public override void SetFields()
        {
            TransitionPopupProperty = new TransitionPopupProperty("Лестница");
        }
    }
}
