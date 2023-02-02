using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    [field: TextArea]
    public string description;
    public GameObject model;
    public Sprite icon;
    public int cost;
    public bool canDiscard;
}
