using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    public string text;
    public bool playerIsColliding;
    private GameObject interactMode;

    // Start is called before the first frame update
    void Start()
    {
        interactMode = GameObject.Find("InteractMode");
        playerIsColliding = false;

        if (text == null)
        {
            text = "Wow, this should have content in it! Whoops.";
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogFormat("{0} just collided with {1}", other.name, this.name );
        if (other.name == "Player" && !playerIsColliding)
        {
            playerIsColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player" && playerIsColliding)
        {
            playerIsColliding = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsColliding)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("space")) 
            {
                HandleInput();
            }
        } 
    }

    private void HandleInput()
    {
        if (GameStateManager.isInteractMode)
        {
            // Disable interact mode
            Debug.LogFormat("Player has stopped interacting with {0}. Attempting to hide text.", name);
            interactMode.GetComponent<InteractModeController>().DisableInteractiveMode();
        }
        else
        {
            Debug.LogFormat("Player is interacting with {0}. Attempting to show text.", name);
            interactMode.GetComponent<InteractModeController>().EnableInteractiveMode(text);
        }
    }
}
