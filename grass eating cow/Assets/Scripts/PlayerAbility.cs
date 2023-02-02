using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public CharStats charStats;
    private PlayerController player;
    private bool isEating;
    private float eatTime;


    private void Awake() 
    {
        eatTime = charStats.eatSpeed;
    }
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isEating)
        {
            StartCoroutine(StartEat()); //this will be in inherited scripts later
        }
        /*
        else if(Input.GetKeyDown(KeyCode.Space) && onScoreZone && !isEating)
        {
            //score code here?
        }
        */
    }

    IEnumerator StartEat()
    {
        isEating = true;
        //animator.SetBool("Eat", true);
        float speed = player.moveSpeed;
        player.moveSpeed = 0;
        yield return new WaitForSeconds(eatTime);
        isEating = false;
        player.moveSpeed = speed;
    }
}
