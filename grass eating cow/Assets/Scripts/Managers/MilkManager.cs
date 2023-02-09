using System;
using UnityEngine;

[Serializable]
public class MilkManager
{
    public Color playerColor;            
    public Transform spawnPoint;         
    [HideInInspector] public int playerNumber;             
    [HideInInspector] public int prefabNumber;         
    [HideInInspector] public string coloredPlayerText;
    [HideInInspector] public GameObject instance; 

    private PlayerController milkMovement;
    private PlayerAbility milkAbility;

    // Movement and abilities dependent on player character.
    public void Setup()
    {
        milkMovement = instance.GetComponent<PlayerController>();
        milkAbility = instance.GetComponent<PlayerAbility>();
        //m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;
        spawnPoint.position = Vector3.zero;
        spawnPoint.rotation = Quaternion.identity;
        
        milkMovement.playerNumber = playerNumber;
        milkAbility.playerNumber = playerNumber;

        coloredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">PLAYER " + playerNumber + "</color>";
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
