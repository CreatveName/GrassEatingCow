using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    [SerializeField]
    private float timeLeft = 60;
    public float timer;
    public bool timerStarted = false;
    public TimeSpan timePlaying;
    [SerializeField]
    private float speedFactor;

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
            return;
        }
    }

    void Start()
    {
        timer = timeLeft;
        speedFactor = 1;
    }

    void Update()
    {
        speedFactor += Time.deltaTime/20;
        if (timerStarted)
        {
            timer -= Time.deltaTime * speedFactor;
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
