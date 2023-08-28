using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
