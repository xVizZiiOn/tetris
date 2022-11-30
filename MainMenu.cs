using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject aboutMenu;

    public void StartGame()
    {
       print("Game started");
       SceneManager.LoadScene("Gameplay");
    }


    public void SettingsMenu()
    {
       print("Settings");
       SceneManager.LoadScene("Settings");
    }

    public void Menu()
    {
        print("Main menu");
        SceneManager.LoadScene("Menu");
    }

    public void AboutMenu()
    {
        print("About");
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        print("Exit game");
        Application.Quit();
    }
}
