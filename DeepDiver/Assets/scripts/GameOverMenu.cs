using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public void Restart()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        if (GlobalVariables.ChosenLevel == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (GlobalVariables.ChosenLevel == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 12);
        }

    }

    public void GoMenu()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }
}