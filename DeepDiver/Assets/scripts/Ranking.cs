using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    private ArrayList Time = new ArrayList();
    private ArrayList Name = new ArrayList();
    public Text[] timeLabel;
    public Text[] nameLabel;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Time.Add(PlayerPrefs.GetString(string.Concat("Time", i)));
            Name.Add(PlayerPrefs.GetString(string.Concat("Name", i)));
        }
        for (int i = 0; i < 10; i++)
        {

            timeLabel[i].text = (string)Time[i];
            nameLabel[i].text = Name[i].ToString();
        }
    }
}

