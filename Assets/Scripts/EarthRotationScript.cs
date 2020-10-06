using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotationScript : MonoBehaviour
{
    void Start()
    {
        //Invoke repeating the rotation to earth
        InvokeRepeating("RotateEarth", 0, 0.01f);
    }

    void RotateEarth()
    {
        //Rotates the earth ccw
        gameObject.transform.Rotate(Vector3.forward, 0.1f);
    }

}
