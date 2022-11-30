using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pause;
    public GameObject pauseGameMenu;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 0.8f;
        pause = false;
    }


    public void PauseGame()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }


    public void LoadMenu()
    {
        Time.timeScale = 0.8f;
        SceneManager.LoadScene("Menu");
    }


    public void RestartGame()
    {
        Time.timeScale = 0.8f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
