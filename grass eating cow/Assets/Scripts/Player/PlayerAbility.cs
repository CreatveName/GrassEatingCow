using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public int playerNumber = 1;
    [SerializeField]
    private CharStats charStats;
    [SerializeField]
    private ProgressBar slider;
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private PlayerScore score;
    public bool isEating;
    private float eatTime;
    [SerializeField]
    private int scoreStored;
    public bool onScoreZone;
    private string eatButton;
    [SerializeField]
    private Animator animator;
    public int foodMultiplier;
    private bool isFull;
    private int stomachLvl;

    // Eat time depends on the character that was selected from the character. 
    private void Awake() 
    {
        eatTime = charStats.eatSpeed;
        scoreStored = 0;
        foodMultiplier = 1;
        stomachLvl = 0;
        slider.sliderMax = charStats.stomachSpace;
        
    }
    private void Start() 
    {
        eatButton = "Fire" + playerNumber;
    }
    // The player starts to eat grass.
    void Update()
    {
        if (Input.GetButtonDown(eatButton) && !onScoreZone && !isEating && !isFull) //Makes eat coroutine start only once player is not in the score area, not already eating (prevents spam eating), and not full
        {
            StartCoroutine(StartEat());
            
        }
        else if(Input.GetButtonDown(eatButton) && onScoreZone) //checks if player is on score zone to initiate scoring the point rather than eating
        {
            score.currentScore += scoreStored;
            score.scored = true;
            scoreStored = 0;
            stomachLvl = 0;
            slider.IncrementProgress(stomachLvl);
        }

        if(stomachLvl >= charStats.stomachSpace)
        {
            isFull = true;
        }else
        {
            isFull = false;
        }
    
    }
    
    IEnumerator StartEat()
    {
        isEating = true;
        animator.SetBool("isEating", true);
        float speed = player.moveSpeed; //preserves original movespeed (because we have different movespeeds for different characters)
        player.moveSpeed = 0;
        scoreStored += 1 * foodMultiplier;
        SoundManagerScript.PlaySound("eating");
        yield return new WaitForSeconds(eatTime);
        stomachLvl++;
        slider.IncrementProgress(stomachLvl);
        animator.SetBool("isEating", false);
        isEating = false;
        foodMultiplier = 1;
        player.moveSpeed = speed; //returns movespeed back to normal once done eating
    }
}
