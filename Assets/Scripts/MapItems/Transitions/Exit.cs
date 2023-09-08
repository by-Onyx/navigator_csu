using Assets.Scripts.DataClasses.Models.Types;
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
    public class Exit : Transition
    {
        public Exit() : base()
        {
            TransitionProperties.TransitionType = new TransitionTypeModel()
            {
                id = 5,
                name = "Выход",
            };
        }

        public Exit(TransitionProperties transitionProperties) : base(transitionProperties) { }

        public override void LoadSprite()
        {
            UIProperties.Sprite = Resources.Load<Sprite>("Icons/Ж");
        }

        public override void SetFields()
        {
            TransitionPopupProperty = new TransitionPopupProperty("выход");
        }
    }
}
