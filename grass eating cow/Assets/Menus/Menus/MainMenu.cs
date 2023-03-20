using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CharSelectScreen()
    {
        SceneManager.LoadScene("CharacterSelect"); //plays games from start menu
      
    }
    public void StartSinglePlayer()
    {
        SceneManager.LoadScene("Cut1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayMultiplayer()
    {
        SceneManager.LoadScene("ConnectToServer");
    }
}
