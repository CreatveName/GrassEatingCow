using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameisPaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameisPaused)
            {
                Resume();
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
    

    public  void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    // Quit's the game and closes the window
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Goodbye :(");

    }
    //Reloads the Scene or Heads to the Menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("back to menu");
    }
}