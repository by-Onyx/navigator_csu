using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class Elevator : Transition
    {
        public Elevator() : base()
        { 
            TransitionProperties.TransitionClass = 2;
        }

        public Elevator(TransitionProperties transitionProperties) : base(transitionProperties) { }

        public override void LoadSprite()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/switch_ladder1");
        }

        public override void SetFields()
        {
            TransitionPopupProperty = new TransitionPopupProperty("Лифт");
        }
    }
}
