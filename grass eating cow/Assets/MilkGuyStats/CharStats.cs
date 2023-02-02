using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Creation/Milk Producers")]
public class CharStats : ScriptableObject
{
	public string charName;
    public int moveSpeed;
    public int eatSpeed;
    public int milkScore;
    public Sprite charLook;

    public void PrintMessage()
    {
	    Debug.Log("The " + charName + " character has been loaded.");
    }
}
