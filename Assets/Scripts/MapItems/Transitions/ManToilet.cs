using Assets.Scripts.DataClasses.Models.Types;
using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class ManToilet : Transition
    {
        public ManToilet() : base()
        {
            TransitionProperties.TransitionType = new TransitionTypeModel()
            {
                id = 7,
                name = "Мужской туалет",
            };
        }

        public ManToilet(TransitionProperties transitionProperties) : base(transitionProperties) { }

        public override void LoadSprite()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/М");
        }

        public override void SetFields()
        {
            TransitionPopupProperty = new TransitionPopupProperty("мужской туалет");
        }
    }
}
