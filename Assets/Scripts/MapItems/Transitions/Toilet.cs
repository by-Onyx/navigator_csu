using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class Toilet : Transition
    {
        public Toilet() : base()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/character_T2");

            TransitionProperties.TransitionClass = 3;

            TransitionPopupProperty = new TransitionPopupProperty("Туалет");
        }
    }
}
