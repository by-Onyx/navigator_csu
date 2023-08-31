using Assets.Scripts.DataClasses.Properties.MapItemPopupProperties;
using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using System.Collections.Generic;
using TMPro;
using UIClasses.MapItemButtons;
using UnityEngine;
using UnityEngine.UI;

namespace UIClasses.Popups
{
    public class PopupTransitionPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text header;

        [SerializeField] private Button deleteButton;
        [SerializeField] private Button closeButton;

        public void Init(TransitionButton transitionButton, TransitionPopupProperty property, List<TransitionProperties> deletedTransitions)
        {
            SetHeader(property);

            deleteButton.onClick.AddListener(() => OnDeletePress(transitionButton, deletedTransitions));
            closeButton.onClick.AddListener(() => ClosePopup());
        }

        private void SetHeader(TransitionPopupProperty property)
        {
            header.text = property.Header;
        }

        private void OnDeletePress(TransitionButton transitionButton, List<TransitionProperties> deletedTransitions)
        {
            deletedTransitions.Add(transitionButton.TransitionProperties);
            Destroy(transitionButton.gameObject);
            Destroy(this.gameObject);
        }

        private void ClosePopup()
        {
            this.gameObject.SetActive(false);
        }
    }
}
