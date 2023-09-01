using Assets.Scripts.DataClasses.Models.Types;
using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class Toilet : Transition
    {
        public Toilet() : base()
        {
            TransitionProperties.TransitionType = new TransitionTypeModel()
            {
                id = 3,
                name = "Туалет",
            };
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
