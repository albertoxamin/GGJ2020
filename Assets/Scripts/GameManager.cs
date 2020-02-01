using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float GivenTime = 500f;
    private float startTime;
    private bool isTimerStarted;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Hud.Instance.gameObject.transform.parent);
        
    }

    private void StartTimer()
    {
        isTimerStarted = true;
        startTime = Time.time;
    }

    void Update()
    {
        if (isTimerStarted)
        {
            float time = GivenTime - (Time.time - startTime);
            if (time > 0)
                Hud.Instance.SetRemainingTimeText(time);
            else
                Hud.Instance.SetRemainingTimeText(0);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Scenes/TestLogic");
    }
}
