using Assets.Scripts.UIClasses.MapItemButtons;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.DataClasses.Properties.MapItemProperties
{
    public class TransitionProperties : MapItemProperty
    {
        public int TransitionClass;
        public List<TransitionButton> ConnectedTransitionButtons { get; private set; } = new List<TransitionButton>();

        public TransitionProperties() { }

        public TransitionProperties(float x, float y) : base(x, y) { }
    }
}