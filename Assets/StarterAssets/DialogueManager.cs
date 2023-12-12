using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(string[] dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        // Add any logic to be executed when the dialogue ends
    }

    public void OnNextButtonClick()
    {
        DisplayNextSentence();
    }

}