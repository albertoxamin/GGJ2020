using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Hud : MonoBehaviour
{
    public static Hud Instance;
    [SerializeField] private Text trapsRemainingText, timeRemainingText, interactionText;

    private void Awake()
    {
        Instance = this;
    }

    public void SetTrapText(int done, int total)
    {
        trapsRemainingText.text = $"{done:00}/{total}";
    }

    public void SetRemainingTimeText(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - minutes * 60;
        timeRemainingText.text = $"{minutes:00}:{seconds:00}";
    }

    public void SetInteractionText(string text)
    {
        interactionText.text = text;
    }
}
