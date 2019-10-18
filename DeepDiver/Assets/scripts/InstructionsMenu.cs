using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour {


	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            if (GlobalVariables.ChosenLevel == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            }

            if (GlobalVariables.ChosenLevel == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);
            }
        }
    }
}
