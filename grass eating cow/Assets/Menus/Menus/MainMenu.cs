using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

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

    private void Awake() 
    {
        Time.timeScale = 1; //just in case buttons or other access ways did not resume time
    }
}
