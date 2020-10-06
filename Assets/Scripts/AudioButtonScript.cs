using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButtonScript : MonoBehaviour
{
    public AudioSource audio;
    void Start()
    {
        //Getting reference to audio source component
        audio = gameObject.GetComponent<AudioSource>();
    }
    
    public void PlaySound()
    {
        //Play audio source whenever button is pressed
        audio.Play();
    }
}
