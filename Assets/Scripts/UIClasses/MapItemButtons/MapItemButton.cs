using Assets.Scripts.DataClasses.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIClasses.MapItemButtons
{
    public abstract class MapItemButton : MonoBehaviour
    {
        [SerializeField] protected Button mapItemButton;

        protected void SetPointProperties(UIProperty properties)
        {
            mapItemButton.image.sprite = properties.Sprite;
        }
    }
}
