using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    private int textNumber = 0;
    private string text;
    public string text1;
    public string text2;
    public string text3;
    public string text4;
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
        Debug.LogFormat("{0} just collided with {1}.", other.name, this.name);
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
                //Debug.LogFormat("Text number is {0}", textnumber);
                textNumber = Random.Range(1, 5);
                {
                    if (textNumber == 1)
                    {
                        text = text1;
                    }
                    else if (textNumber == 2)
                    {
                        text = text2;
                    }
                    else if (textNumber == 3)
                    {
                        text = text3;
                    }
                    else if (textNumber == 4)
                    {
                        text = text4;
                    }
                }
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
