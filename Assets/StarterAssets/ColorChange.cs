using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChange : MonoBehaviour
{
    public Color startColor = Color.red;
    public Color endColor = Color.blue;
    public float colorChangeSpeed = 5f;
    public AudioClip audioClip;
    public TextMeshProUGUI gameSavedText;

    private AudioSource audioSource;
    private bool isPlayerNear = false;
    public float playerProximityThreshold = 3f; // Adjust the threshold as needed

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = audioClip;

        if (gameSavedText == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned to ColorChange script. Please assign it in the inspector.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && isPlayerNear)
        {
            StartCoroutine(ChangeColor());

            if (audioClip != null)
            {
                audioSource.Play();
            }

            ShowGameSavedText();
            Debug.Log("Game saved!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            HideGameSavedText();
        }
    }

    IEnumerator ChangeColor()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * colorChangeSpeed;

            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);

            yield return null;
        }

        HideGameSavedText();
    }

    void ShowGameSavedText()
    {
        gameSavedText.gameObject.SetActive(true);
    }

    void HideGameSavedText()
    {
        gameSavedText.gameObject.SetActive(false);
    }
}
