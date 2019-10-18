using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking2 : MonoBehaviour {

    private ArrayList Time2 = new ArrayList();
    private ArrayList Name2 = new ArrayList();
    public Text[] timeLabel2;
    public Text[] nameLabel2;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Time2.Add(PlayerPrefs.GetString(string.Concat("Time2", i)));
            Name2.Add(PlayerPrefs.GetString(string.Concat("Name2", i)));
        }
        for (int i = 0; i < 10; i++)
        {

            timeLabel2[i].text = (string)Time2[i];
            nameLabel2[i].text = Name2[i].ToString();
        }
    }
}
