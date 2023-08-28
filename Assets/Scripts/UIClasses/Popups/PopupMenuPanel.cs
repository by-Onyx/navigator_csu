using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIClasses.Popups
{
    public class PopupMenuPanel : MonoBehaviour
    {
        [SerializeField] private Toggle isDisabled;
        [SerializeField] private Toggle isTransitionVisible;

        public bool IsDisabled 
        { 
            get 
            {
                return isDisabled.isOn;
            }
        }
        public bool IsTransitionVisible
        {
            get
            {
                return isTransitionVisible.isOn;
            }
        }
        

    }
}
