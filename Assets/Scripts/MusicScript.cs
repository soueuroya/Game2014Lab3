using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    void Start()
    {
        //Don't destroy the music whenever changing the scenes.
        DontDestroyOnLoad(gameObject);
    }
}
