using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingMenu2 : MonoBehaviour {

    public ArrayList puntuations2 = new ArrayList();
    public ArrayList names2 = new ArrayList();
    public string timer2;
    public string time2;
    public string newname2;
    public int position2;


    // Use this for initialization
    void Start()
    {
        if (!GlobalVariables.NoSavePuntuation)
        {


            timer2 = PlayerPrefs.GetString("Time2");
            string[] splitTimer2 = timer2.Split(new string[] { " : " }, StringSplitOptions.None);

            newname2 = PlayerPrefs.GetString("NewName2");


            for (int i = 0; i < 10; i++)
            {
                puntuations2.Add(PlayerPrefs.GetString(string.Concat("Time2", i)));
                names2.Add(PlayerPrefs.GetString(string.Concat("Name2", i)));
            }


            for (int i = 0; i < 10; i++)
            {
                time2 = (string)puntuations2[i];

                if (!time2.Equals(""))
                {
                    string[] splitTime2 = time2.Split(new string[] { " : " }, StringSplitOptions.None);

                    if (int.Parse(splitTime2[0]) > int.Parse(splitTimer2[0]))
                    {
                        position2 = i;
                        break;
                    }
                    if (int.Parse(splitTime2[0]) < int.Parse(splitTimer2[0]))
                    {
                        position2 = i + 1;
                        break;
                    }
                    if (int.Parse(splitTime2[0]) == int.Parse(splitTimer2[0]))
                    {
                        if (int.Parse(splitTime2[1]) > int.Parse(splitTimer2[1]))
                        {
                            position2 = i;
                            break;
                        }
                        if (int.Parse(splitTime2[1]) < int.Parse(splitTimer2[1]))
                        {
                            position2 = i + 1;
                            break;
                        }
                        if (int.Parse(splitTime2[1]) == int.Parse(splitTimer2[1]))
                        {
                            if (int.Parse(splitTime2[2]) > int.Parse(splitTimer2[2]))
                            {
                                position2 = i;
                                break;
                            }
                            if (int.Parse(splitTime2[2]) < int.Parse(splitTimer2[2]))
                            {
                                position2 = i + 1;
                                break;
                            }
                        }
                    }
                }

            }

            puntuations2.Insert(position2, timer2);
            names2.Insert(position2, newname2);

            for (int i = 0; i < 10; i++)
            {

                PlayerPrefs.SetString(string.Concat("Time2", i), (string)puntuations2[i]);
                PlayerPrefs.SetString(string.Concat("Name2", i), (string)names2[i]);
            }

            PlayerPrefs.Save();
        }
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void GoMenu()
    {
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 18);
    }

    public void SaveScore()
    {
        GlobalVariables.NoSavePuntuation = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
    }
}
