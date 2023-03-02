using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] milkProducer;
    public int selectedCharacter = 0;
    private LoadStats ldS;
    [SerializeField]
    private int playerNum;
    private bool playerTwo;

    private void Start() 
    {
        LoadCharStat();
    }

    // When pressing the right button in the game selection screen it moves to pick the next character in line.
    public void NextCharacter()
    {
        milkProducer[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % milkProducer.Length;
        milkProducer[selectedCharacter].SetActive(true);
        LoadCharStat();
    }

    // When pressing the left button in the game selection screen it moves to pick the previous character that was just previewed.
    public void PreviousCharacter()
    {
        milkProducer[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += milkProducer.Length;
        }
        milkProducer[selectedCharacter].SetActive(true);
        LoadCharStat();
    }

    // Confirms the character that is currently on your screen to be set as your playable character.
    public void PickCharacter()
    {
        PlayerPrefs.SetInt("selectedCharacter" + playerNum.ToString(), selectedCharacter);
        SceneManager.LoadScene("GameScreen");
    }

    private void LoadCharStat()
    {
        ldS = milkProducer[selectedCharacter].GetComponent<LoadStats>();
        ldS.LoadStat();
    }

    public void AddPlayerNum()
    {
        // Option to add the second player by pressing the + button in the character selection screen
        if(playerTwo)
        {
            PlayerPrefs.SetInt("numOfPlayers", 2);
        }else
        {
            PlayerPrefs.SetInt("numOfPlayers", 1);
        }
            
    }

    public void PlayerT(bool l)
    {
        playerTwo = l;
    }

}
