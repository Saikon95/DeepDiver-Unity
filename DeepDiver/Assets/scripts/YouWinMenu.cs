using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinMenu : MonoBehaviour
{
    public void Restart()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void GoMenu()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void GoRanking()
    {
        GlobalVariables.NoSavePuntuation = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
    }
    public void SaveScore()
    {
        GlobalVariables.NoSavePuntuation = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
    }
}