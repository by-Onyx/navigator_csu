using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using Assets.Scripts.MapItems.Transitions;
using UIClasses.Popups;

namespace UIClasses.MapItemButtons
{
    public class TransitionButton : MapItemButton
    {
        public TransitionProperties TransitionProperties { get; private set; }

        public void Init(Transition transition, PopupTransitionPanel popup)
        {
            this.TransitionProperties = transition.TransitionProperties;
            TransitionProperties.X = gameObject.transform.position.x;
            TransitionProperties.Y = gameObject.transform.position.y;
            SetPointProperties(transition.UIProperties);
            SetActionOnClick(popup);
        }

        protected void SetActionOnClick(PopupTransitionPanel popup)
        {
            mapItemButton.onClick.AddListener(delegate
            {
                popup.gameObject.transform.SetAsLastSibling();
                popup.gameObject.SetActive(true);
            });
        }
    }
}
