using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public int playerNumber = 1;
    [SerializeField]
    private CharStats charStats;
    private PlayerController player;
    private PlayerScore score;
    private bool isEating;
    private float eatTime;
    [SerializeField]
    private int scoreStored;
    public bool onScoreZone;


    private void Awake() 
    {
        eatTime = charStats.eatSpeed;
        scoreStored = 0;
    }
    void Start()
    {
        player = GetComponent<PlayerController>();
        score = GetComponent<PlayerScore>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !onScoreZone && !isEating)
        {
            StartCoroutine(StartEat()); 
        }
        else if(Input.GetKeyDown(KeyCode.Space) && onScoreZone && !isEating)
        {
            score.currentScore += scoreStored;
            score.scored = true;
            scoreStored = 0;
        }
    
    }

    IEnumerator StartEat()
    {
        isEating = true;
        //animator.SetBool("Eat", true);
        float speed = player.moveSpeed;
        player.moveSpeed = 0;
        scoreStored++;
        yield return new WaitForSeconds(eatTime);
        isEating = false;
        player.moveSpeed = speed;
    }
}
