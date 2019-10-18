using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimePanel : MonoBehaviour
{

    public Text timeLabel;
    private string timer;

    public TimerUI timerUI;



    // Use this for initialization
    void Start()
    {
        timer = PlayerPrefs.GetString("Time");
        timeLabel.text = timer.ToString();
    }
}
