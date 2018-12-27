using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Transform t;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform> ();

        // Check for invalid or missing speed values
        if (speed < 0f) {
            Debug.LogError("[PLAYER] Player speed is not set correctly — it should be a positive value.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
