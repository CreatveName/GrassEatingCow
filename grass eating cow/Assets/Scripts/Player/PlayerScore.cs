using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private CharStats charStat;
    public int currentScore;
    public bool scored;
    private int milkScore;
    private int totalScore;
    private LevelTimer tim;

    
    private void Awake() 
    {
        currentScore = 0;
        PlayerPrefs.SetInt("combinedScore", 0);
        tim = LevelTimer.instance;
    }
    void Start()
    {
        milkScore = charStat.milkScore;
    }
    // Keeps track of the total score which is current score of playing + the score added from producing milk
    void Update()
    {
        if(scored)
        {
            SoundManagerScript.PlaySound("bell");
            totalScore = currentScore * milkScore;

            AddTime(totalScore);

            int combinedScore = totalScore + PlayerPrefs.GetInt("combinedScore");
            PlayerPrefs.SetInt("combinedScore", combinedScore);
            currentScore = 0;
            scored = false;
        }
    }

    void AddTime(int score)
    {
        int addTime = score / milkScore; //Balances out the time add ons for pets with more score per food
        tim.timer += addTime;
    }
}
