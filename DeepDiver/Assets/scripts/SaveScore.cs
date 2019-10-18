using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveScore : MonoBehaviour {

    private InputField input;
    private string Name;

    void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }
    public void getInput(string name)
    {
        if (GlobalVariables.ChosenLevel == 1)
        {
            Name = name;
            PlayerPrefs.SetString("NewName", Name);
            PlayerPrefs.Save();
            input.text = "";
        }
        else
        {
            if (GlobalVariables.ChosenLevel == 2)
            {
                Name = name;
                PlayerPrefs.SetString("NewName2", Name);
                PlayerPrefs.Save();
                input.text = "";
            }
        }

    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();
        if (GlobalVariables.ChosenLevel == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 10);
        }
        else
        {
            if (GlobalVariables.ChosenLevel == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            }
        }

    }

    public void GoMenu()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 11);
    }

    public void GoRanking()
    {
        if (GlobalVariables.ChosenLevel == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            if (GlobalVariables.ChosenLevel == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
            }
        }

    }
}
