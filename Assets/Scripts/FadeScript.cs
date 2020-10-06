using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    // The game manager
    public GameManager gm;

    // If it is suppoused to load a scene
    public bool loadingScene;

    // The fade animator
    public Animator anim;

    // If it is suppoused to fade the music, get's the reference to it
    public AudioSource music;
    public bool fadeMusic;


    // Enum with all the scenes of the game
    public enum Scenes
    {
        StartGame,
        LevelFinished,
        Instructions,
        GameOver,
        NextLevel,
        MainMenu,
        ExitGame,
        None
    }

    // Variable holding the scene it is suppoused to load after fade
    public Scenes sceneToLoad;

    void Start()
    {
        if (loadingScene) // If it is suppoused to load a main menu scene
        {
            sceneToLoad = Scenes.MainMenu;
            GoTransparentComeBack(); // Fade in and fade out
        }

        if (fadeMusic) // if it is suppoused to fade the music
        {
            GameObject musicGObject = GameObject.Find("Music");
            if (musicGObject != null) // get the reference to the audio source
            {
                music = musicGObject.GetComponent<AudioSource>();
            }
            else
            {
                CreateMusicObject();
            }
        }
    }

    void CreateMusicObject()
    {
        gm.CreateMusicObject();
    }

    public void GoBlack() // Turn to black
    {
        /*if (!anim.gameObject.activeSelf)
        {
            anim.gameObject.SetActive(true); // TODO: Fix fade if not active on scene
        }*/

        anim.SetTrigger("GoBlack");
    }

    public void GoTransparent() // Turn transparent
    {
        anim.SetTrigger("GoTransparent");
    }

    public void GoTransparentComeBack() // Fade in and fade out
    {
        anim.SetTrigger("GoTransparentComeBack");
    }

    public void FadeMusic() // Fade the music
    {
        if (music != null)
        {
            InvokeRepeating("VolumeDown", 0, 0.1f); // Invoke repeating a volume down function
        }
    }

    public void VolumeDown() // function that lowers tha volume
    {
        music.volume -= 0.1f;
        if (music.volume <= 0.1f) // If volume is almost faded, stop the invoke repeating
        {
            CancelInvoke("VolumeDown");
        }
    }

    public void AnimationFinished() // When the animation finished choses what scene to lead next
    {
        switch (sceneToLoad)
        {
            case Scenes.StartGame: gm.StartGame();
                break;
            case Scenes.LevelFinished: gm.LevelFinished();
                break;
            case Scenes.Instructions: gm.LoadInstructions();
                break;
            case Scenes.GameOver: gm.GameOver();
                break;
            case Scenes.NextLevel: gm.NextLevel();
                break;
            case Scenes.MainMenu: gm.MainMenu();
                break;
            case Scenes.ExitGame: gm.ExitGame();
                break;
            default:
            case Scenes.None:
                break;
        }
    }

    public void StartGame() // Game start
    {
        sceneToLoad = Scenes.StartGame;
        FadeMusic();
        GoBlack();
    }

    public void LevelFinished() // Level Finished
    {
        sceneToLoad = Scenes.LevelFinished;
        GoBlack();
    }

    public void NextLevel() // Next level
    {
        sceneToLoad = Scenes.NextLevel;
        GoBlack();
    }

    public void GameOver() // Game over
    {
        sceneToLoad = Scenes.GameOver;
        FadeMusic();
        GoBlack();
    }

    public void LoadInstructions() // Instructions
    {
        sceneToLoad = Scenes.Instructions;
        GoBlack();
    }

    public void MainMenu() // Main menu
    {
        sceneToLoad = Scenes.MainMenu;
        GoBlack();
    }
    public void ExitGame() // Exit Game
    {
        sceneToLoad = Scenes.ExitGame;
        FadeMusic();
        GoBlack();
    }
}
