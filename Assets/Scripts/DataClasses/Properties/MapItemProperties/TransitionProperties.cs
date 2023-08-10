﻿using System;
using System.Collections.Generic;

namespace Assets.Scripts.DataClasses.Properties.MapItemProperties
{
    [Serializable]
    public class TransitionProperties : MapItemProperty
    {
        public List<TransitionProperties> properties { get; private set; } = new List<TransitionProperties>();

        public TransitionProperties() { }

        public TransitionProperties(float x, float y) : base(x, y) { }
    }
}