using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{

    public Text timerLabel;
    private float time;
    private float stoppedTime;
    private bool stop = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            time += Time.deltaTime;
        }


        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//Use the euclidean division for the seconds.
        var fraction = (time * 100) % 100;

        timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
    }
    public void stopTime()
    {
        if (GlobalVariables.ChosenLevel == 1)
        {
            PlayerPrefs.SetString("Time", timerLabel.text);
        }
        else
        {
            if (GlobalVariables.ChosenLevel == 2)
            {
                PlayerPrefs.SetString("Time2", timerLabel.text);
            }
        }

        PlayerPrefs.Save();
        stop = true;
    }
}
