using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingMenu : MonoBehaviour {

    public ArrayList puntuations = new ArrayList();
    public ArrayList names = new ArrayList();
    public string timer;
    public string time;
    public string newname;
    public int position;


    // Use this for initialization
    void Start () {
        if (!GlobalVariables.NoSavePuntuation)
        {

       
            timer = PlayerPrefs.GetString("Time");
            string[] splitTimer = timer.Split(new string[] { " : " }, StringSplitOptions.None);

            newname = PlayerPrefs.GetString("NewName");

        
            for (int i = 0; i < 10; i++)
            {
                puntuations.Add(PlayerPrefs.GetString(string.Concat("Time", i)));
                names.Add(PlayerPrefs.GetString(string.Concat("Name", i)));
            }
        

            for (int i = 0; i < 10 ; i++)
            {
                time = (string)puntuations[i];

                if (!time.Equals(""))
                {
                    string[] splitTime = time.Split(new string[] { " : " }, StringSplitOptions.None);

                    if (int.Parse(splitTime[0]) > int.Parse(splitTimer[0]))
                    {
                        position = i;
                        break;
                    }
                    if (int.Parse(splitTime[0]) < int.Parse(splitTimer[0]))
                    {
                        position = i+1;
                        break;
                    }
                    if (int.Parse(splitTime[0]) == int.Parse(splitTimer[0]))
                    {
                        if (int.Parse(splitTime[1]) > int.Parse(splitTimer[1]))
                        {
                            position = i;
                            break;
                        }
                        if (int.Parse(splitTime[1]) < int.Parse(splitTimer[1]))
                        {
                            position = i + 1;
                            break;
                        }
                        if (int.Parse(splitTime[1]) == int.Parse(splitTimer[1]))
                        {
                            if (int.Parse(splitTime[2]) > int.Parse(splitTimer[2]))
                            {
                                position = i;
                                break;
                            }
                            if (int.Parse(splitTime[2]) < int.Parse(splitTimer[2]))
                            {
                                position = i + 1;
                                break;
                            }
                        }
                    }
                }
           
            }

            puntuations.Insert(position, timer);
            names.Insert(position, newname);

            for (int i = 0; i < 10; i++)
            {

                PlayerPrefs.SetString(string.Concat("Time", i), (string)puntuations[i]);
                PlayerPrefs.SetString(string.Concat("Name", i), (string)names[i]);
            }

            PlayerPrefs.Save();
        }
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 11);
    }

    public void GoMenu()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 12);
    }

    public void SaveScore()
    {
        GlobalVariables.NoSavePuntuation = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

