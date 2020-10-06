using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonScript : MonoBehaviour
{
    public GameManager gm;
    
    public void ResumeGame()
    {
        // If pause menu exits, call game manager resume game
        gm.ResumeGame();
    }
}
