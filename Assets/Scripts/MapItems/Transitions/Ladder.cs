using Assets.Scripts.DataClasses.Models.Types;
using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class Ladder : Transition
    {
        public Ladder() : base()
        {
            TransitionProperties.TransitionType = new TransitionTypeModel()
            {
                id = 1,
                name = "Лестница",
            };
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
