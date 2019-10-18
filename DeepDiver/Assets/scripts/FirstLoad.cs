using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoad : MonoBehaviour {

    public Resolution[] resolutions;
    public int resolutionIndex;

    // Use this for initialization
    void Start () {

        resolutions = Screen.resolutions;
        LoadSettings();
    }

    public void LoadSettings()
    {
        //AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.pause = PlayerPrefs.GetInt("musicOn") == 1 ? true : false; ;
        Screen.fullScreen = PlayerPrefs.GetInt("fullScreen") == 1 ? true : false; ;
        resolutionIndex = PlayerPrefs.GetInt("resolutionIndex");

        CoinPanel.coinAmount = PlayerPrefs.GetInt("Ncoins");
        //CoinPanel.coinAmount = 5000;

        UpgradesShop.buyed = PlayerPrefs.GetInt("buyed") == 1 ? true : false; ;

        if (UpgradesShop.buyed)
        {
            Debug.Log("buyd");  
            PlayerController.numberLifes = PlayerPrefs.GetInt("Nlifes");
            PlayerController.ammo = PlayerPrefs.GetInt("Nattacks");
            //PlayerController.nAir = PlayerPrefs.GetInt("Nairs");
            AirPanel.airRate = PlayerPrefs.GetInt("Nairs");

            UpgradesShop.ExcesLife = PlayerPrefs.GetInt("ExcesLife");
            UpgradesShop.ExcesAttack = PlayerPrefs.GetInt("ExcesAttack");
            UpgradesShop.ExcesAir = PlayerPrefs.GetInt("ExcesAir");
        }
        else
        {
            Debug.Log("nobuyd");
            PlayerController.numberLifes = 3;
            PlayerController.ammo = 3;
            //PlayerController.nAir = 5;
            AirPanel.airRate = 15;
        }

        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }
}
