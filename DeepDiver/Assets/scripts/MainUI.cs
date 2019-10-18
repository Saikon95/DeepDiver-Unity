using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

    public string mainMenuScene;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public bool isPaused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused)
            {
                ResumeGame();
            }
            else {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }

        }
	}

    public void ResumeGame() {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMain() {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        Time.timeScale = 1f;
        if (GlobalVariables.ChosenLevel == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (GlobalVariables.ChosenLevel == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 14);
        }
    }

    public void GoOptions() {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void GoBackGame()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

}
