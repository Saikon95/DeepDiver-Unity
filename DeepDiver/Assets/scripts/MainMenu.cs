using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Start()
    {
        GlobalVariables.ChosenRanking = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 13);
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void ChooseShop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }

    public void Items()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
    }

    public void DeleteData()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
    }

    public void GoRanking()
    {
        GlobalVariables.NoSavePuntuation = true;
        GlobalVariables.ChosenRanking = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 16);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
