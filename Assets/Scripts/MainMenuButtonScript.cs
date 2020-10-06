using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonScript : MonoBehaviour
{
    public GameManager gm;

    public void MainMenu()
    {
        // If button main menu is pressed, call game manager main menu screen
        gm.MainMenu();
    }
}
