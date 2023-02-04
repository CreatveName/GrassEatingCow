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
}
