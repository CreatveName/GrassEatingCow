using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Type of Food", menuName = "Food Menu")]


public class Food: ScriptableObject
{
    public string foodName;
    public string description;
    public Sprite foodLook;
    public int value = 100;
    public int spawnTime;

}
