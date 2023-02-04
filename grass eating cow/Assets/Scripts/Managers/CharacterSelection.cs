using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] milkProducer;
    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        milkProducer[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % milkProducer.Length;
        milkProducer[selectedCharacter].SetActive(true);
    }

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

    public void PickCharacter()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }
}
