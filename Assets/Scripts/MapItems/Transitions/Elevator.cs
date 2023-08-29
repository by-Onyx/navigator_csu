using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class Elevator : Transition
    {
        public Elevator() : base()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/switch_ladder1");

            TransitionProperties.TransitionClass = 2;

            TransitionPopupProperty = new TransitionPopupProperty("Лифт");
        }
    }
}
