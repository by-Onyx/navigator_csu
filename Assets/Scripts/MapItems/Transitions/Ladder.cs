using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class Ladder : Transition
    {
        public Ladder() : base()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/ladder1");

            TransitionProperties.TransitionClass = 1;

            TransitionPopupProperty = new TransitionPopupProperty("Лестница");
        }
    }
}
