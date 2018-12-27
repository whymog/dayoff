using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
