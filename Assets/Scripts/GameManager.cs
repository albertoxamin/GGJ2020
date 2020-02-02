using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public float GivenTime = 500f;
    private float time;
    private bool timerPaused;
    private bool isTimerStarted;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject RespawnMenu;

    public static GameManager Instance;
    public int traps;
    private int _notBrokenTraps;

    public int notBrokenTraps
    {
        get { return _notBrokenTraps; }
        set
        {
            Hud.Instance.SetTrapText(value, traps);
            _notBrokenTraps = value;
        }
    }

    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Hud.Instance.gameObject.transform.parent);
        Hud.Instance.SetTrapText(0, traps);
    }

    void StartTimer()
    {
        isTimerStarted = true;
        timerPaused = false;
        time = GivenTime + 1f; //the timer starts to display the GivenTime -1
    }

    void StopTimer()
    {
        isTimerStarted = false;
        time = GivenTime;
    }

    void RestartTimer()
    {
        if (isTimerStarted)
        {
            if (timerPaused)
                time = GivenTime;
            else
                time = GivenTime + 1f; //fix the timer starts to display the GivenTime -1
        }
    }

    void PauseTimer()
    {
        if (isTimerStarted)
            if (!timerPaused)
                timerPaused = true;
    }

    void UnPauseTimer()
    {
        if (timerPaused)
            timerPaused = false;
    }

    void Update()
    {
        if (isTimerStarted)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (timerPaused)
                    UnPauseTimer();
                else
                    PauseTimer();
            }

            if (!timerPaused)
                time -= Time.deltaTime;

            if (time > 0)
                Hud.Instance.SetRemainingTimeText(time);
            else
                Hud.Instance.SetRemainingTimeText(0);
        }
        else Hud.Instance.SetRemainingTimeText(time);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isTimerStarted)
                StopTimer();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isTimerStarted || timerPaused)
                StartTimer();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartTimer();
        }
    }


    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Scenes/New Scene");
        mainMenu.SetActive(false);
        StartTimer();
    }

    public void Respawn()
    {
        SceneManager.LoadSceneAsync("Scenes/New Scene");
        RespawnMenu.SetActive(false);
        StopTimer();
        StartTimer();
    }

    public void Death()
    {
        SceneManager.LoadScene("Scene/Respawn",LoadSceneMode.Additive);

    }

    public void Quit()
    {
        Application.Quit();
    }
    


}