using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    
    public float timeLeft = 60;
    public float timer;
    public bool timerStarted = false;
    public TimeSpan timePlaying;

    public static LevelTimer instance;

    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
    }

    void Start()
    {
        timer = timeLeft;
    }

    void Update()
    {
        if (timerStarted)
        {
            timer -= Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(timer);
        }
        
        // Displays the time is up and assists with the Game Over Canvas
        if (timer <= 0)
        {
            Debug.Log("Time's up!");
            timerStarted = false;
        }
    }

}
