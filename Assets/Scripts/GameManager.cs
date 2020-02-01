using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float GivenTime = 500f;
    private float startTime;
    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float time = GivenTime - (Time.time - startTime);
        if (time > 0)
            Hud.Instance.SetRemainingTimeText(time);
        else
            Hud.Instance.SetRemainingTimeText(0);
    }
}
