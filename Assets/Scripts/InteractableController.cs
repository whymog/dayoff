using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    int textnumber = 0;
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
        //Debug.LogFormat("Text number is {0}", textnumber);
        textnumber = Random.Range(1, 5);

        if (playerIsColliding)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("space")) 
            {
                HandleInput();
            }
        }
        if (textnumber is 1)
        {
            text = text1;
        }
        if (textnumber is 2)
        {
            text = text2;
        }
        if (textnumber is 3)
        {
            text = text3;
        }
        if (textnumber is 4)
        {
            text = text4;
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
