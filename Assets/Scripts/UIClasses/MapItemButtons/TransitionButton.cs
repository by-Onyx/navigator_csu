using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using Assets.Scripts.MapItems.Transitions;
using Assets.Scripts.UIClasses.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UIClasses.MapItemButtons
{
    public class TransitionButton : MapItemButton
    {
        public TransitionProperties TransitionProperties { get; private set; }
        private Connection connection = Connection.GetInstance();

        public void Init(Transition transition, PopupTransitionPanel popup)
        {
            this.TransitionProperties = transition.TransitionProperties;

            SetPointProperties(transition.UIProperties);
            SetActionOnClick(popup);
        }

        protected void SetActionOnClick(PopupTransitionPanel popup)
        {
            mapItemButton.onClick.AddListener(delegate
            {
                if(connection.isConnectionProcess)
                {
                    connection.TransitionButtons.Add(this);
                }
                else
                {
                    popup.gameObject.transform.SetAsLastSibling();
                    popup.gameObject.SetActive(true);
                }
            });
        }
    }
}
