using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField]
    private Collider2D coll;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerAbility boolTest = other.GetComponent<PlayerAbility>();
        OnlinePAbility bools = other.GetComponent<OnlinePAbility>();

        if(boolTest)
        {
            boolTest.onScoreZone = true;
        }

        if(bools)
        {
            bools.onScoreZone = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        PlayerAbility boolTest = other.GetComponent<PlayerAbility>();
        OnlinePAbility bools = other.GetComponent<OnlinePAbility>();

        if(boolTest)
        {
            boolTest.onScoreZone = false;
        }

        if(bools)
        {
            bools.onScoreZone = false;
        }
    }
}
