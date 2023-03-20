using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<MilkManager> players;
    [SerializeField]
    private GameObject[] milkProducer;
    [SerializeField]
    private LevelTimer timer;
    [SerializeField]
    private TextMeshProUGUI messageText;  
    [SerializeField]
    private TextMeshProUGUI timerText; 
    [SerializeField]
    private TextMeshProUGUI gameOverText; 
    [SerializeField]
    private float startDelay = 3f;         
    [SerializeField]
    private float endDelay = 3f;   
    private WaitForSeconds startWait;     
    private WaitForSeconds endWait;  
    private bool levelStarted;
    [SerializeField]
    private Canvas gameOver;
    private int playerAmount;
    [SerializeField]
    private int selectedCharacter;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    void Start()
    {
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);
        gameOver.enabled = false;
        
        // Gives us the option in adding an additional player
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

            string scoreString = "Score: " + PlayerPrefs.GetInt("combinedScore");
            scoreText.text = scoreString;
        }

        if(timer.timer <= 0 && levelStarted)
        {
            StartCoroutine(LevelEnd());
            levelStarted = false;
        }
    }

    private void SpawnAllPlayers()
    {
        // Processed used for spawning All players
        for (int i = 0; i < players.Count; i++)
        {
            int p2 = players[i].playerNumber + 1;
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
        // Countdown for level starting, after timer runs out it enables te players to move.
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
        // Once the timer hits zero, disables movement of the player and pops up the final score and ending buttons.
        for (int i = 0; i < players.Count; i++)
        {
            players[i].DisableControl();
        }
        messageText.text = "Time's Up!";
        gameOverText.text = "Final Score: " + PlayerPrefs.GetInt("combinedScore").ToString();
        timerText.text = string.Empty;

        yield return endWait;
        messageText.text = string.Empty;
        gameOver.enabled = true;
        //CANVAS/END MENU POP UP CODE HERE
    }


}
