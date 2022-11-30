using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;


    public void LoadMenu()
    {
        Time.timeScale = 0.8f;
        SceneManager.LoadScene("Menu");
    }


    public void RestartGame()
    {
        Time.timeScale = 0.8f;
        TetrisBlock.fallTime = 0.8f;
        TetrisBlock.speed = 0.8f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
