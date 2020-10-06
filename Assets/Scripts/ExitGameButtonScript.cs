using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButtonScript : MonoBehaviour
{
    public GameManager gm;
    
    public void ExitGame() // When the exit button is pressed, call game manager  exit game function
    {
        gm.ExitGame();
    }
}
