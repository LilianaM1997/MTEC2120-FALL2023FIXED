using System.Collections;
using UnityEngine;
using TMPro;

public class PickUpItem : Interactable
{
    [Header("Item Data")]
    [SerializeField] string itemName;
    [SerializeField] int scoreValue = 10;

    private TextMeshProUGUI scoreText;
    public AudioSource coinSound; 

    public override void Start()
    {
        base.Start();
        interactableName = itemName;

        scoreText = FindObjectOfType<TextMeshProUGUI>();

        if (scoreText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found in the scene. Make sure it exists and is active.");
        }

        
       
    }

    protected override void Interaction()
    {
        base.Interaction();
        print("I put " + itemName + " in my inventory.");

        // Play a simple sound effect
        coinSound.Play();

        // Increase the score when picking up the item
        ScoreManager.Instance.IncreaseScore(scoreValue);

        Destroy(this.gameObject);

        // Display the updated score in the TextMeshProUGUI component
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Coins: " + ScoreManager.Instance.CurrentScore;
            scoreText.fontSize = 48;
            scoreText.fontStyle = FontStyles.Bold;
            RectTransform canvasRectTransform = scoreText.GetComponent<RectTransform>();
            if (canvasRectTransform != null)
            {
                canvasRectTransform.sizeDelta = new Vector2(200f, 50f);
            }
        }
    }
}
