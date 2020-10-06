using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestButtonBehaviour : MonoBehaviour
{
    public TMP_Text LivesLabel;
    public TMP_Text ScoreLabel;

    public void OnTestButtonPressed()
    {
        LivesLabel.rectTransform.anchoredPosition = new Vector2(370.0f, -83.0f);
        ScoreLabel.rectTransform.anchoredPosition = new Vector2(-353.0f, -83.0f);
    }
}
