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
    [SerializeField]
    private TextMeshProUGUI nameT;
    [SerializeField]
    private TextMeshProUGUI speedT;
    [SerializeField]
    private TextMeshProUGUI eatT;
    [SerializeField]
    private TextMeshProUGUI scoreT;
    [SerializeField]
    private TextMeshProUGUI stomachS;
    [SerializeField]
    private Image picCool;
    

    public void LoadStat()
    {
	    DisplayStats();
    }

    void DisplayStats()
    {
        nameT.text = "Name: " + charStat.charName;
        speedT.text = "Speed: " + charStat.moveSpeed;
        eatT.text = "Eating Speed: " + charStat.eatSpeed;
        scoreT.text = "Milk Score: " + charStat.milkScore;
        stomachS.text = "Stomach: " + charStat.stomachSpace;
        picCool.sprite = charStat.charLook;
    }
}
