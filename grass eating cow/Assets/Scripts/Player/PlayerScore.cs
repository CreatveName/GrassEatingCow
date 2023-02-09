using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private CharStats charStat;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    public int currentScore;
    public bool scored;
    private int milkScore;
    public int totalScore;


    private void Awake() 
    {
        currentScore = 0;
        scoreText.text = "Score: " + currentScore.ToString();
    }
    void Start()
    {
        milkScore = charStat.milkScore;
    }

    void Update()
    {
        if(scored)
        {
            totalScore = currentScore * milkScore;
            scoreText.text = "Score: " + totalScore.ToString();
            PlayerPrefs.SetInt("totalScore", totalScore);
            scored = false;
        }
    }
}
