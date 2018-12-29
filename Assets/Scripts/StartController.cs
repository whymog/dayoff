using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("Room");
        }
    }
}
