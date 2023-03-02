using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public MilkManager[] players;
    public GameObject[] milkProducer;
    public LevelTimer timer;
    public TextMeshProUGUI messageText;  
    public TextMeshProUGUI timerText; 
    public TextMeshProUGUI gameOverText; 
    public float startDelay = 3f;         
    public float endDelay = 3f;   
    private WaitForSeconds startWait;     
    private WaitForSeconds endWait;  
    private bool levelStarted;
    public Canvas gameOver;
    private int playerAmount;

    public List<MilkManager> players;
    public int selectedCharacter;

    void Start()
    {
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);
        gameOver.enabled = false;
        
        playerAmount = PlayerPrefs.GetInt("numOfPlayers");

        if(playerAmount == 2)
        {
            MilkManager m2 = new MilkManager();
            players.Add(m2);
        }

        SpawnAllPlayers();
        StartCoroutine(LevelStart());
    }

    private void FixedUpdate() 
    {
        if(levelStarted)
        {
            string timeString = "Time: " + timer.timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = timeString;
        }

        if(timer.timer <= 0 && levelStarted)
        {
            StartCoroutine(LevelEnd());
            levelStarted = false;
        }
    }

    private void SpawnAllPlayers()
    {
        for (int i = 0; i < players.Count; i++)
        {
            int p2 = players[i].playerNumber;
            string p =  "selectedCharacter" + p2;
            print(p);
            selectedCharacter = PlayerPrefs.GetInt(p);
            players[i].instance = Instantiate(milkProducer[selectedCharacter], this.transform.position, this.transform.rotation) as GameObject;
            players[i].playerNumber = i + 1;
            players[i].Setup();
        }
    }

    private IEnumerator LevelStart()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].DisableControl();
        }
        messageText.text = "Level Start!";
        timerText.text = string.Empty;
        yield return startWait;

        for (int i = 0; i < players.Count; i++)
        {
            players[i].EnableControl();
        }
        messageText.text = string.Empty;
        timer.timerStarted = true;
        levelStarted = true;
    }

    private IEnumerator LevelEnd()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].DisableControl();
        }
        messageText.text = "Time's Up!";
        gameOverText.text = "Final Score: " + PlayerPrefs.GetInt("totalScore").ToString();
        timerText.text = string.Empty;

        yield return endWait;
        messageText.text = string.Empty;
        gameOver.enabled = true;
        //CANVAS/END MENU POP UP CODE HERE
    }


}
