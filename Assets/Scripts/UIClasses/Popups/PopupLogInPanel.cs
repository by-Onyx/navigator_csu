using System.Collections;
using Assets.Scripts.UIClasses.Menus;
using Assets.Scripts.UIClasses.Popups;
using DataClasses;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIClasses.Popups
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
            => loginButton.onClick.AddListener(Enter);

        private void Enter()
            => StartCoroutine(Login());
        
        private IEnumerator Login()
        {
            var facadeApi = new FacadeAPI();

            var isSuccess = facadeApi.Login(login.text, password.text);

            if (isSuccess.Current)
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
            yield break;
        }
    }
}