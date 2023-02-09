using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Type of Food", menuName = "Food Menu")]


public class FoodObjects: ScriptableObject
{
    public string foodName;
    public string description;
    public Sprite foodLook;
    public float value = 100;

}
