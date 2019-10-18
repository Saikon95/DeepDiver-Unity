using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteDataScript : MonoBehaviour {

    public GameObject deleted;
    public GameObject sure;

    public void yesButton()
    {
        PlayerController.ammo = 3;
        UpgradesShop.buyed = false;
        UpgradesShop.ExcesAir = 0;
        UpgradesShop.ExcesAttack = 0;
        UpgradesShop.ExcesLife = 0;
        CoinPanel.coinAmount = 0;
        ItemShop.item1 = 0;
        ItemShop.item2 = 0;
        ItemShop.item3 = 0;
        /*ChooseItems.chooseItem1 = 0;
        ChooseItems.chooseItem2 = 0;
        ChooseItems.chooseItem3 = 0;
        */

        PlayerPrefs.SetInt("Nattacks", PlayerController.ammo);
        PlayerPrefs.SetInt("buyed", UpgradesShop.buyed ? 1 : 0);
        PlayerPrefs.SetInt("ExcesLife", UpgradesShop.ExcesLife);
        PlayerPrefs.SetInt("ExcesAttack", UpgradesShop.ExcesAttack);
        PlayerPrefs.SetInt("ExcesAir", UpgradesShop.ExcesAir);
        PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
        PlayerPrefs.SetInt("MejoraMoney", ItemShop.item1);
        PlayerPrefs.SetInt("MejoraTraje", ItemShop.item2);
        PlayerPrefs.SetInt("MejoraAtaque", ItemShop.item3);
        PlayerPrefs.SetInt("ChooseItem1", 0);
        PlayerPrefs.SetInt("ChooseItem2", 0);
        PlayerPrefs.SetInt("ChooseItem3", 0);
        for (int i = 0; i < 10; i++)
        {

            PlayerPrefs.SetString(string.Concat("Time", i), "");
            PlayerPrefs.SetString(string.Concat("Name", i), "");
        }

        PlayerPrefs.Save();

        sure.SetActive(false);
        deleted.SetActive(true);       

    }

    public void noButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 8);
    }

    public void okButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 8);
    }
}
