using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("MoveDown", 0, 0.05f); // Invokes a repeating function that moves the background
    }

    // Moves the background down
    void MoveDown()
    {
        gameObject.transform.Translate(-Vector3.up * 0.02f);
        if (gameObject.transform.position.y < -10.68f) // If it reaches the limit, it goes back to the top
        {
            gameObject.transform.Translate(Vector3.up * 10.68f * 2);
        }
    }
}
