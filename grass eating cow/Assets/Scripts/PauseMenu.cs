using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PauseMenu : MonoBehaviour
{
    private static bool gameisPaused = false;
    [SerializeField]
    private GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameisPaused)
            {
                Resume();
                gameisPaused = false;
            }
            else
            {
                Pause();
            }
        }
    }   
        // Stops the UI in order to pause the game
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameisPaused = true;
    }

    public void PauseOnline() //We decided it would be better for other players to stay playing if one person wants to pause/leave
    {
        PauseMenuUI.SetActive(true);
        gameisPaused = true;
    }

    public  void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    // Quit's the game and closes the window
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Goodbye");

    }
    //Reloads the Scene or Heads to the Menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("back to menu");
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }
}