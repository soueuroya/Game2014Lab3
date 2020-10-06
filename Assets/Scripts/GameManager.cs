using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Keeps the current level
    public int currentLevel = 1;
    
    //Reference to the fade image
    public FadeScript fade;
    
    //If it has a different music, it should change to it and set it's volume.
    public bool changeMusic;
    public AudioClip music;
    public float volume;
    
    //If the game is paused show to pause menu
    public bool paused;
    public GameObject pauseMenu;

    private void Start()
    {
        if (changeMusic) // If it is suppoused to change the music:
        {
            GameObject musicObject = GameObject.Find("Music");
            if (musicObject != null) // Check if music game object is found
            {
                AudioSource audio = musicObject.GetComponent<AudioSource>();
                if (audio != null) // Check if there is a audio source in the object
                {
                    if (audio.clip != music) // Check if it is a different music
                    {
                        audio.clip = music; // Change the music and set the other values
                        audio.Play();
                        audio.loop = true;
                        if (volume != 0) // If volume is different than default, change it
                        {
                            audio.volume = volume;
                        }
                    }
                }
                else
                {
                    Debug.LogError("No clip in music"); // Debug shouldn't appear, if it appears, it means one object is suppoused to play a music but it has no music
                }
            }
            else
            {
                CreateMusicObject();
            }
        }
    }

    public void CreateMusicObject()
    {
        GameObject musicGObject = new GameObject("Music");
        AudioSource audioSource = musicGObject.AddComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.volume = volume;
        audioSource.Play();
    }

    public void TogglePause() // Toggle the pause screen if escape is pressed
    {
        if (pauseMenu != null)
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame() // Pauses the Game
    {
        paused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() // Resumes the game
    {
        paused = false;
        pauseMenu.SetActive(false);
    }

    public void StartGame() // Load Level 1 Scene
    {
        
        SceneManager.LoadScene("Level1");
    }

    public void LevelFinished() // TODO: Will load the end level scene
    {
        SceneManager.LoadScene("Scoreboard");
    }

    public void NextLevel() // TODO: Will load the next level
    {
        currentLevel++;
        SceneManager.LoadScene("Level"+currentLevel);
    }

    public void GameOver() // Loads the game over Scene
    {
        SceneManager.LoadScene("GameOVer");
    }

    public void LoadInstructions() // Loads the instructions scene
    {
        SceneManager.LoadScene("Instructions");
    }

    public void MainMenu() // Loads the main menu scene
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MainMenuFromFade() // Loads the main menu scene
    {
        fade.gameObject.SetActive(true);
        fade.MainMenu();
    }

    public void ExitGameFromFade() // Loads the main menu scene
    {
        fade.gameObject.SetActive(true);
        fade.ExitGame();
    }

    public void ExitGame() // Exits the game
    {
        if (Application.platform == RuntimePlatform.Android) // Check if its on android, sets game to sleep
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }
        else // if not on android
        {
            #if UNITY_EDITOR // If in unity editor
                UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER // If in unity web player
                 Application.OpenURL(webplayerQuitURL);
            #else // anything else (Running on Operacional Systems)
                 Application.Quit();
            #endif
        }
    }
}
