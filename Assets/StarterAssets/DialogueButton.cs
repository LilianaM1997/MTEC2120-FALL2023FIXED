using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void Start()
    {
        // Ensure the DialogueManager is assigned to the button
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager not assigned to the button!");
            return;
        }

        // Add a click event listener to the button
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Call the OnNextButtonClick method of the DialogueManager
        dialogueManager.OnNextButtonClick();
    }
}
