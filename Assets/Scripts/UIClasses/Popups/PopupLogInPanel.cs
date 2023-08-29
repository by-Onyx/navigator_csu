using Assets.Scripts.UIClasses.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIClasses.Popups
{
    public class PopupLogInPanel : MonoBehaviour
    {
        [SerializeField] private Button loginButton;
        [SerializeField] private TMP_InputField login;
        [SerializeField] private TMP_InputField password;
        [SerializeField] private ErrorLoginPanel errorPanel;
        [SerializeField] private MenuAdminPanel menuAdminPanel;
        [SerializeField] private MenuUserPanel menuUserPanel;

        private void Awake()
        {
            loginButton.onClick.AddListener(Enter);
        }

        private void Enter()
        {
            if (login.text == "AAA" && password.text == "123")
            {
                menuUserPanel.gameObject.SetActive(false);
                menuAdminPanel.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
                errorPanel.gameObject.transform.SetAsLastSibling();
                errorPanel.gameObject.SetActive(true);
            }
        }
    }
}
