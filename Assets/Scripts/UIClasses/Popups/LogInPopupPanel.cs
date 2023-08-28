using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UIClasses.Popups
{
    public class LogInPopupPanel : MonoBehaviour
    {
        [SerializeField] private Button loginButton;
        [SerializeField] private TMP_InputField login;
        [SerializeField] private TMP_InputField password;
        [SerializeField] private ErrorLoginPanel errorPanel;

        private void Awake()
        {
            loginButton.onClick.AddListener(Enter);
        }

        private void Enter()
        {
            if(login.text == "AAA" && password.text == "123") 
            {
                Debug.Log("Yraaaaa");
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
