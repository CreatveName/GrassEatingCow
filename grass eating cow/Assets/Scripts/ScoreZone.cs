using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private Collider2D coll;

    private void Start() 
    {
        coll = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerAbility boolTest = other.GetComponent<PlayerAbility>();

        if(boolTest)
        {
            boolTest.onScoreZone = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        PlayerAbility boolTest = other.GetComponent<PlayerAbility>();

        if(boolTest)
        {
            boolTest.onScoreZone = false;
        }
    }
}
