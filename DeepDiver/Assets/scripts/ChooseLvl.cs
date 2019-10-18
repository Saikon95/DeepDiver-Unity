using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLvl : MonoBehaviour {

    static bool firstTime = true;

    public void GoBack()
    {
        if (GlobalVariables.ChosenRanking == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 16);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 13);
        }

    }

    public void GoFirstLevel()
    {
        

        if (GlobalVariables.ChosenRanking == true)
        {
            GlobalVariables.ChosenLevel = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            GlobalVariables.ChosenLevel = 1;
            if (firstTime)
            {
                firstTime = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 12);
            }
        }

    }

    public void GoSecondLevel()
    {
        

        if (GlobalVariables.ChosenRanking == true)
        {
            GlobalVariables.ChosenLevel = 2;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            GlobalVariables.ChosenLevel = 2;
            if (firstTime)
            {
                firstTime = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
