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
    private PlayerController player;
    private PlayerScore score;
    public bool isEating;
    private float eatTime;
    private int scoreStored;
    public bool onScoreZone;
    private string eatButton;
    private Animator animator;
    public int foodMultiplier;
    private bool isFull;
    private int stomachLvl;
    private float scoreDelay = 0.5f;

    // Eat time depends on the character that was selected from the character. 
    private void Awake() 
    {
        eatTime = charStats.eatSpeed;
        scoreStored = 0;
        foodMultiplier = 1;
        stomachLvl = 0;
        slider.sliderMax = charStats.stomachSpace;
    }
    void Start()
    {
        player = GetComponent<PlayerController>();
        score = GetComponent<PlayerScore>();
        animator = GetComponent<Animator>();
        eatButton = "Fire" + playerNumber;
    }
    // The player starts to eat grass.
    void Update()
    {
        if (Input.GetButtonDown(eatButton) && !onScoreZone && !isEating && !isFull)
        {
            StartCoroutine(StartEat());
            SoundManagerScript.PlaySound("eating");
        }
        else if(Input.GetButtonDown(eatButton) && onScoreZone)
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
        scoreStored = 1 * foodMultiplier;
        yield return new WaitForSeconds(eatTime);
        stomachLvl++;
        slider.IncrementProgress(stomachLvl);
        animator.SetBool("isEating", false);
        isEating = false;
        foodMultiplier = 1;
        player.moveSpeed = speed; //returns movespeed back to normal once done eating
    }
}
