using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableNPC : Interactable
{
    private Animator animator;
    public TextMeshProUGUI textComponent; // Reference to your TextMeshProUGUI component
    public string[] lines; // Dialogue lines
    public float textSpeed; // Speed of text display
    public GameObject DialogueBox; // Reference to your dialogue panel GameObject

    private int index;
    private bool isTyping; // Flag to check if typing effect is in progress

    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        // Disable the TextMeshProUGUI component and the dialogue panel initially
        textComponent.gameObject.SetActive(false);
        if (DialogueBox != null)
        {
            DialogueBox.SetActive(false);
        }
    }

    protected override void Interaction()
    {
        base.Interaction();

        if (Input.GetKeyDown(KeyCode.E)) // Check for E button press
        {
            if (!isTyping)
            {
                // Enable the TextMeshProUGUI component and the dialogue panel when starting dialogue
                textComponent.gameObject.SetActive(true);
                if (DialogueBox != null)
                {
                    DialogueBox.SetActive(true);
                }
                StartCoroutine(StartDialogue());
            }
        }
    }

    IEnumerator StartDialogue()
    {
        index = 0;

        while (index < lines.Length)
        {
            isTyping = true;
            yield return StartCoroutine(TypeLine(lines[index]));
            isTyping = false;

            yield return new WaitForSeconds(textSpeed); // Add a delay between lines if needed

            index++;

            if (index < lines.Length)
            {
                textComponent.text = string.Empty; // Clear text for the next line
            }
        }

        // Disable the TextMeshProUGUI component and the dialogue panel when the dialogue is finished
        textComponent.gameObject.SetActive(false);
        if (DialogueBox != null)
        {
            DialogueBox.SetActive(false);
        }
    }

    IEnumerator TypeLine(string line)
    {
        foreach (char c in line.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Wait for user input to proceed to the next line
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
    }
}
