using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehaviour : MonoBehaviour
{

    public void OnStartButtonPressed()
    {
        // If start button is pressed, starts scene Play
        SceneManager.LoadScene("Play");
    }
}
