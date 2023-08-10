using Assets.Scripts.DataClasses.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIClasses.MapItemButtons
{
    public abstract class MapItemButton : MonoBehaviour
    {
        [SerializeField] private Button mapItemButton;

        protected void SetPointProperties(UIProperty properties)
        {
            var colors = mapItemButton.colors;
            colors.normalColor = properties.Color;
            mapItemButton.colors = colors;
        }

        protected void SetOnClick(GameObject popup)
        {
            mapItemButton.onClick.AddListener(delegate
            {
                popup.SetActive(true);
            });
        }
    }
}
