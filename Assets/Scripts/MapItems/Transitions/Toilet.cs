using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class Toilet : Transition
    {
        public Toilet() : base()
        {
            TransitionProperties.TransitionClass = 3;
        }

        public Toilet(TransitionProperties transitionProperties) : base(transitionProperties) { }

        public override void LoadSprite()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/character_T2");
        }

        public override void SetFields()
        {
            TransitionPopupProperty = new TransitionPopupProperty("Туалет");
        }
    }
}
