using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateManager : MonoBehaviour {
    private static GameStateManager _gm;
    public static GameStateManager GetInstance() {
        return _gm;
    }

    public static bool isInteractMode;

    public static int startHour = 8;
    public static int endHour = 23;
    public static int currentHour;

    public static int playerStress = 100;
    public static int playerProductivity = 0;

    public GameObject clockText;
    public GameObject stressText;
    public GameObject productivityText;

    private static string timeDisplayText;

    // Start is called before the first frame update
    void Start() {
        _gm = this;
        isInteractMode = false;  

        // Initialize playable hours
        currentHour = startHour;

        // Initialize starting player stats
        playerStress = 100;
        playerProductivity = 0;

        SetTime();
        SetStats();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void incrementTime() {
        if (currentHour < endHour) {
            currentHour += 1;
            Debug.LogFormat("The time is now {0}:00.", currentHour);
            SetTime();
        } else if (currentHour >= endHour) {
            // TODO: Add an ending to the game
            SceneManager.LoadScene("Title Screen");
        }
    }

    private void SetTime() {
        Debug.LogFormat("The time is now {0}:00.", currentHour);

        timeDisplayText = "It's " + currentHour + ":00.";
        clockText.GetComponent<TextMeshPro>().SetText(timeDisplayText);
    }

    public void UpdateStats(int addToProductivity, int addToStress) {
        if (addToProductivity != 0) {
            playerProductivity += addToProductivity;
        }
        if (addToStress != 0) {
            playerStress += addToStress;
        }

        SetStats();
    }

    private void SetStats() {
        stressText.GetComponent<TextMeshPro>().SetText("Stress: " + playerStress);
        productivityText.GetComponent<TextMeshPro>().SetText("Productivity: " + playerProductivity);
    }
}
