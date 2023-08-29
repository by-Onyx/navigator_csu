using System.Collections;
using System.Text;
using Assets.Scripts.UIClasses.Menus;
using Assets.Scripts.UIClasses.Popups;
using DataClasses.Models.DTO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
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

        private const string URL = "http://localhost:8000/api/auth/login";

        private void Awake() 
            => loginButton.onClick.AddListener(Enter);

        private void Enter()
            => StartCoroutine(Login());
        
        private IEnumerator Login()
        {
            var loginRequest = new LoginRequest
            {
                login = login.text,
                password = password.text
            };
            var json = JsonUtility.ToJson(loginRequest);
            var request = PrepareRequest(json);

            yield return request.SendWebRequest();

            if (request.responseCode == 200L)
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

        private UnityWebRequest PrepareRequest(string json)
        {
            var formData = new WWWForm();
            var request = UnityWebRequest.Post(URL, formData);
            
            var postBytes = Encoding.UTF8.GetBytes(json);
            var uploadHandler = new UploadHandlerRaw(postBytes);
            request.uploadHandler = uploadHandler;
            
            request.SetRequestHeader("accept", "*/*");
            request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");

            return request;
        }
    }
}