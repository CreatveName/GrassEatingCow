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
    private string eatButton;
    private Animator animator;


    private void Awake() 
    {
        eatTime = charStats.eatSpeed;
        scoreStored = 0;
    }
    void Start()
    {
        player = GetComponent<PlayerController>();
        score = GetComponent<PlayerScore>();
        animator = GetComponent<Animator>();
        eatButton = "Fire" + playerNumber;
    }

    void Update()
    {
        if (Input.GetButton(eatButton) && !onScoreZone && !isEating)
        {
            StartCoroutine(StartEat()); 
        }
        else if(Input.GetButton(eatButton) && onScoreZone && !isEating)
        {
            score.currentScore += scoreStored;
            score.scored = true;
            scoreStored = 0;
        }
    
    }

    IEnumerator StartEat()
    {
        isEating = true;
        animator.SetBool("isEating", true);
        float speed = player.moveSpeed; //preserves original movespeed (because we have different movespeeds for different characters)
        player.moveSpeed = 0;
        scoreStored++;
        yield return new WaitForSeconds(eatTime);
        animator.SetBool("isEating", false);
        isEating = false;
        player.moveSpeed = speed; //returns movespeed back to normal once done eating
    }
}
