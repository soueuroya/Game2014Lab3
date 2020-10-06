using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButtonScript : MonoBehaviour
{
    public GameObject pageToHide;
    public GameObject pageToShow;
    public GameObject btnToHide;
    public GameObject btnToShow;

    public float yPos;
    
    void Start()
    {
        yPos = gameObject.transform.localPosition.y;
    }

    //When button is pressed, it hides its page and shows the other one
    public void OnButtonPressed()
    {
        pageToShow.SetActive(true);
        pageToHide.SetActive(false);
        btnToHide.transform.localPosition = new Vector3(5000, yPos, 0);
        btnToShow.transform.localPosition = new Vector3(0, yPos, 0);
    }

}
