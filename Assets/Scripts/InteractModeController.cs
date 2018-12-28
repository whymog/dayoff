using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractModeController : MonoBehaviour
{
    public GameObject interactModeView;
    public GameObject textBox;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;

        interactModeView.SetActive(isActive);
        textBox.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive != GameStateManager.isInteractMode) {
            isActive = GameStateManager.isInteractMode;

            interactModeView.SetActive(isActive);
            textBox.SetActive(isActive);
        }
    }

    public void EnableInteractiveMode(string text)
    {
        if (!isActive)
        {
            if (text == null)
            {
                Debug.LogError("[INTERACTABLE] No text was provided when enabling interactive mode. Please ensure you're passing a string when calling this method.");
                return;
            }

            Debug.Log("Attempting to display text: " + text);

            TextMeshPro textBoxText = textBox.GetComponentInChildren<TextMeshPro>();
            // Set the textBoxText equal to whatever text was passed in

            textBoxText.SetText(text);
            GameStateManager.isInteractMode = true;
        }
    }

    public void DisableInteractiveMode()
    {
        if (isActive)
        {
            GameStateManager.isInteractMode = false;
        }
    }
}
