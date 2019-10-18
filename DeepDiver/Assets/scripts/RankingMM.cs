using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingMM : MonoBehaviour {

    public void GoMenu()
    {
        if (GlobalVariables.ChosenLevel == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 15);
        }
        else
        {
            if (GlobalVariables.ChosenLevel == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 17);
            }

        }
        
    }
}
