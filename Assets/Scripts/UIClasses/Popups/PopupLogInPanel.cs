using Assets.Scripts.UIClasses.Menus;
using Assets.Scripts.UIClasses.Popups;
using ControllerClients;
using DataClasses;
using DataClasses.Models.Requests;
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

        private async void Enter()
        {
            var loginControllerClient = new LoginControllerClient();
            var response = await loginControllerClient.LogIn(new LoginRequest
                { login = login.text, password = password.text });
            if (response is not null)
            {
                Debug.Log(response.Value.token);
                Config.JwtToken = response.Value.token;
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