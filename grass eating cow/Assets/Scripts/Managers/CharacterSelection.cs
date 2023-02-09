using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] milkProducer;
    public int selectedCharacter = 0;

    // When pressing the right button in the game selection screen it moves to pick the next character in line.
    public void NextCharacter()
    {
        milkProducer[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % milkProducer.Length;
        milkProducer[selectedCharacter].SetActive(true);
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
    }

    // Confirms the character that is currently on your screen to be set as your playable character.
    public void PickCharacter()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene("GameScreen");
    }
}
