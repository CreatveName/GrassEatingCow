using System;
using UnityEngine;

[Serializable]
public class MilkManager //Single player only
{            
    [HideInInspector] public int playerNumber = 1;             
    [HideInInspector] public int prefabNumber;         
    [HideInInspector] public GameObject instance; 

    private PlayerController milkMovement;
    private PlayerAbility milkAbility;

    // Movement and abilities dependent on player character.
    public void Setup()
    {
        milkMovement = instance.GetComponent<PlayerController>();
        milkAbility = instance.GetComponent<PlayerAbility>();
        
        milkMovement.playerNumber = playerNumber;
        milkAbility.playerNumber = playerNumber;
    }

    // Disables the player from moving while producing milk
    public void DisableControl()
    {
        milkAbility.enabled = false;
        milkMovement.enabled = false;
    }
    // Re-enables control of the player after they finish producing milk.
    public void EnableControl()
    {
        milkAbility.enabled = true;
        milkMovement.enabled = true;
    }
}
