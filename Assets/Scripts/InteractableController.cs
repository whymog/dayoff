using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    private GameStateManager gm;
    private GameObject interactMode;
    private int index = 0;
    private int timesInteracted = 0;
    private string text;

    public string[] textOptions;
    public int addToStress = 0;
    public int addToProductivity = 0;
    public bool playerIsColliding;

    void Start() {
        interactMode = GameObject.Find("InteractMode");
        playerIsColliding = false;

        if (text == null) {
            text = "Wow, this should have content in it! Whoops.";
        }

        // Set the initial text seed at random
        index = Random.Range(0, textOptions.Length);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.LogFormat("{0} just collided with {1}.", other.name, this.name);
        if (other.name == "Player" && !playerIsColliding) {
            playerIsColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player" && playerIsColliding) {
            playerIsColliding = false;
        }
    }

    void Update() {
        if (playerIsColliding) {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("space")) {
                HandleInput();
            }
        }
    }

    private void HandleInput() {
        if (GameStateManager.isInteractMode) {
            // Disable interact mode if it's already active
            Debug.LogFormat("Player has stopped interacting with {0}. Attempting to hide text.", name);
            interactMode.GetComponent<InteractModeController>().DisableInteractiveMode();

            // Update the game time after done interacting
            gm = GameStateManager.GetInstance();
            gm.incrementTime();
            gm.UpdateStats(addToProductivity, addToStress);
        } else if (timesInteracted < textOptions.Length) {
            // Get new text to display
            text = textOptions[index];

            // Show text
            Debug.LogFormat("Player is interacting with {0}. Attempting to show text.", name);
            interactMode.GetComponent<InteractModeController>().EnableInteractiveMode(text);

            // Increment index, or if it's at the maximum, loop back to zero
            index = (index == textOptions.Length - 1) ? 0 : index + 1;

            timesInteracted ++;
        }
    }
}
