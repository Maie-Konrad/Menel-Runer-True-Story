using System;
using System.Collections;
using System.Drawing;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class TextGenerator : MonoBehaviour
{

    public delegate int ChosenSelection();
    private Coroutine typingCoroutine;

    [SerializeField] private bool isManual;

    [Header("TMP Manual Config")]
    [SerializeField] private TextMeshProUGUI textToDisplayTMP;
    [SerializeField] private float speedGenerateTMP = 0.05f;
    [TextArea(3, 10)][SerializeField] private string textToMessageTMP;

    private string textToDisplay;
    private bool isCoroutineRunning = false;

    private void Start()
    {
        if (isManual && textToDisplayTMP != null)
        {
            StartManualTyping();
        }
        else if (isManual)
        {
            Debug.LogError("TextToDisplayTMP is not assigned in inspector!");
        }
    }
 
    private void StartManualTyping()
    {
        if (!isCoroutineRunning)
        {
            isCoroutineRunning = true;
            typingCoroutine = StartCoroutine(TextTypingCoroutine(textToMessageTMP, speedGenerateTMP));
        }
    }

    public string GenerateText(string text, float speed)
    {
        return GenerateText(text, speed, true);
    }

    public string GenerateText(string text, float speed, bool canRun)
    {
        if (string.IsNullOrEmpty(text))
        {
            Debug.LogWarning("Text is null or empty");
            return string.Empty;
        }

        if (!canRun)
        {
            StopTyping();
            return string.Empty;
        }

      

        if (!isCoroutineRunning)
        {
            isCoroutineRunning = true;
            typingCoroutine = StartCoroutine(TextTypingCoroutine(text, speed));
           
        }


        return textToDisplay;
    }

    private void StopTyping()
    {
        if (isCoroutineRunning && typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        isCoroutineRunning = false;
        Debug.Log("Stopped Coroutine");
    }

    private IEnumerator TextTypingCoroutine(string text, float typeSpeed)
    {
        // Reset text
        if (isManual && textToDisplayTMP != null)
        {
            textToDisplayTMP.text = string.Empty;
        }
        else
        {
            textToDisplay = string.Empty;
        }

        // Type text character by character
        for (int i = 0; i < text.Length; i++)
        {
            if (isManual)
            {
                if (textToDisplayTMP == null)
                {
                    Debug.LogError("TextToDisplayTMP became null during typing!");
                    yield break; 
                }
                textToDisplayTMP.text += text[i];
            }
            else
            {
                textToDisplay += text[i];
            }
            yield return new WaitForSeconds(typeSpeed);
        }

        typingCoroutine = null;
    }

    private void OnDestroy()
    {
        StopTyping();
    }

    private void OnDisable()
    {
        StopTyping();
    }
}