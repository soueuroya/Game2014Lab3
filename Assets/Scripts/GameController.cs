using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TMP_Text LivesLabel;
    public TMP_Text ScoreLabel;

    private float livesLabelHalfWidth;
    private float livesLabelHalfHeight;

    private float scoreLabelHalfWidth;
    private float scoreLabelHalfHeight;

    public CanvasScaler scaler;
    public Vector2 scale;

    void Start()
    {
        var currentResolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        scale = currentResolution / scaler.referenceResolution;

        livesLabelHalfWidth = LivesLabel.rectTransform.rect.width * 0.5f * scale.x;
        livesLabelHalfHeight = LivesLabel.rectTransform.rect.height * 0.5f * scale.y;
        scoreLabelHalfWidth = ScoreLabel.rectTransform.rect.width * 0.5f * scale.x;
        scoreLabelHalfHeight = ScoreLabel.rectTransform.rect.height * 0.5f * scale.y;
    }

    void Update()
    {
        LivesLabel.rectTransform.position = new Vector2(Screen.safeArea.xMin + livesLabelHalfWidth, Screen.safeArea.yMax - livesLabelHalfHeight);
        ScoreLabel.rectTransform.position = new Vector2(Screen.safeArea.xMax - scoreLabelHalfWidth, Screen.safeArea.yMax - livesLabelHalfHeight);
    }
}
