﻿using Assets.Scripts.DataClasses.Properties;
using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using UnityEngine;

namespace Assets.Scripts.MapItems.Transitions
{
    public class Ladder : Transition
    {
        public Ladder() : base()
        {
            UIProperties.Color = Color.blue;

            TransitionPopupProperty = new TransitionPopupProperty("Лестница");
        }
    }
}
