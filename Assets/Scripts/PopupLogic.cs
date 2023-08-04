using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupLogic : MonoBehaviour
{
    [SerializeField] private TMP_InputField firstField;
    [SerializeField] private TMP_InputField secondField;
    [SerializeField] private TMP_InputField thirdField;
    [SerializeField] private Button saveBtn;
    [SerializeField] private Button deleteBtn;

    private PointProperties pointProperties;

    private void Awake()
    {
        saveBtn.onClick.AddListener(DisablePopup);
        deleteBtn.onClick.AddListener(DisablePopup);
    }

    public void EnablePopup(PointProperties pointProperties)
    {
        this.pointProperties = pointProperties;
        SetTextFields();
        ShowPopup();
    }

    private void DisablePopup()
    {
        SaveTextFields();
        this.pointProperties = null;
        HidePopup();
    }

    private void HidePopup()
    {
        gameObject.SetActive(false);
    }

    private void ShowPopup()
    {
        gameObject.transform.SetAsLastSibling();
        gameObject.SetActive(true);
    }

    private void SaveTextFields()
    {
        pointProperties.TextFirst = firstField.text;
        pointProperties.TextSecond = secondField.text;
        pointProperties.TextThird = thirdField.text;
    }

    private void SetTextFields()
    {
        firstField.text = pointProperties.TextFirst;
        secondField.text = pointProperties.TextSecond;
        thirdField.text = pointProperties.TextThird;
    }
}
