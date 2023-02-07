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
        void Pause()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameisPaused = true;
        }
    }

  public  void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Goodbye :(");

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Debug.Log("back to menu");

    }
}