using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

//Have to make online versions of a lot of our scripts to implement Photon functions without ruining single player :D
public class OnlineGameManager : MonoBehaviour
{
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
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Transform[] spawnPoints;
    public static OnlineGameManager instance;
    public static int onlineScore = 0;
    [SerializeField]
    PhotonView view;
    
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
        SetScoreText("0");//should already be set to 0, but just in case
    }
    
    void Start()
    {
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);
        gameOver.enabled = false;

        SpawnAllPlayers();
        StartCoroutine(LevelStart()); 
    }

    void SetScoreText(string st)
    {
        scoreText.text = st;
    }

    private void FixedUpdate() 
    {
        if(levelStarted)
        {
            string timeString = "Time: " + timer.timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = timeString;

            string scoreString = "Score: " + onlineScore.ToString();
            SetScoreText(scoreString);
        }

        if(timer.timer <= 0 && levelStarted)
        {
            StartCoroutine(LevelEnd());
            levelStarted = false;
        }
    }

    private void SpawnAllPlayers()
    {
        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        GameObject playerToSpawn = milkProducer[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }

    private IEnumerator LevelStart()
    {
        // Countdown for level starting, after timer runs out it enables te players to move.

        messageText.text = "Make Milk or face the farmer's WRATH!!!";
        timerText.text = string.Empty;
        yield return startWait;

        messageText.text = string.Empty;
        timer.timerStarted = true;
        levelStarted = true;
    }

    private IEnumerator LevelEnd()
    {
        // Once the timer hits zero, disables movement of the player and pops up the final score and ending buttons.

        messageText.text = "Time's Up!";
        gameOverText.text = "Final Score: " + onlineScore.ToString();
        timerText.text = string.Empty;

        yield return endWait;
        messageText.text = string.Empty;
        gameOver.enabled = true;
        yield return 1.5f;
        this.view.RPC(nameof(Freeze), RpcTarget.All); //Have to do after a moment to prevent client sided freezes preventing menu from popping up
        //CANVAS/END MENU POP UP CODE HERE
    }
    [PunRPC]
    void Freeze()
    {
        Time.timeScale = 0;
    }
}
