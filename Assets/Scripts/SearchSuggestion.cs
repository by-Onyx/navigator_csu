using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class SearchSuggestion : MonoBehaviour
{
    [SerializeField] public InputField searchField;
    [SerializeField] public GameObject buttonPrefab;
    [SerializeField] public Transform buttonContainer;

    private static List<string> suggestions;

    private void Start()
    {
        searchField.onValueChanged.AddListener(OnSearchFieldValueChanged);
    }

    public void Init(List<string> names)
    {
        suggestions = names;
    }

    private void OnSearchFieldValueChanged(string fieldValue)
    {
        ClearSuggestions();

        if (!string.IsNullOrEmpty(fieldValue))
        {
            List<string> matchingSuggestions = suggestions
                .FindAll(suggestion => suggestion.Contains(fieldValue))
                .Take(3)
                .ToList();
            if (matchingSuggestions.Count > 0)
            {
                foreach (string suggestion in matchingSuggestions)
                {
                    CreateSuggestionButton(suggestion);
                }
            }
        }
    }
    private void CreateSuggestionButton(string suggestion)
    {
        GameObject buttonGO = Instantiate(buttonPrefab, buttonContainer);

        Button button = buttonGO.GetComponent<Button>();

        button.GetComponentInChildren<Text>().text = suggestion;
        button.transform.SetAsLastSibling();

        button.onClick.AddListener(() => OnSuggestionButtonClicked(suggestion));
    }

    private void OnSuggestionButtonClicked(string suggestion)
    {
        searchField.text = suggestion;
        ClearSuggestions();
    }

    private void ClearSuggestions()
    {
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
