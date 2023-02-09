using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadStats : MonoBehaviour
{
    // TextMesh GUI for the character selection screen that displays the stats of each animal.
    [SerializeField]
    private CharStats charStat;
    public TextMeshProUGUI nameT;
    public TextMeshProUGUI speedT;
    public TextMeshProUGUI eatT;
    public TextMeshProUGUI scoreT;
    public Image picCool;

    void Start()
    {
	    DisplayStats();
	    charStat.PrintMessage();
    }

    void DisplayStats()
    {
        nameT.text = "Name: " + charStat.charName;
        speedT.text = "Speed: " + charStat.moveSpeed;
        eatT.text = "Eating Speed: " + charStat.eatSpeed;
        scoreT.text = "Milk Score: " + charStat.milkScore;
        picCool.sprite = charStat.charLook;
    }
}
