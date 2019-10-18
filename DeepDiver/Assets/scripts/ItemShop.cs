using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour {
    public static int item1;
    public static int item2;
    public static int item3;
    public static int chooseItem1;
    public static int chooseItem2;
    public static int chooseItem3;

    // Use this for initialization
    void Start () {
        item1 = PlayerPrefs.GetInt("MejoraMoney");
        item2 = PlayerPrefs.GetInt("MejoraTraje");
        item3 = PlayerPrefs.GetInt("MejoraAtaque");
        chooseItem1 = PlayerPrefs.GetInt("ChooseItem1");
        chooseItem2 = PlayerPrefs.GetInt("ChooseItem2");
        chooseItem3 = PlayerPrefs.GetInt("ChooseItem3");
        if (chooseItem1 == 1)
        {
            GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usando";
        }
        if (item1==1 && chooseItem1==0)
        {
            GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usar";
        }
        if (chooseItem2 == 1)
        {
            GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usando";
        }
        if (item2 == 1 && chooseItem2 == 0)
        {
            GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usar";
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        

    }
    public void BuyM()
    {
        chooseItem1 = PlayerPrefs.GetInt("ChooseItem1");
        item1 = PlayerPrefs.GetInt("MejoraMoney");
        Debug.Log(item1);
        if (CoinPanel.coinAmount >= 100 && item1 == 0)
        {
            item1 = 1;
            chooseItem1 = 1;
            chooseItem2 = 0;
            GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usando";
            if (item2 == 1)
            {
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usar";
            }
            CoinPanel.coinAmount = CoinPanel.coinAmount - 100;
            PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);  
            PlayerPrefs.SetInt("MejoraMoney", 1);
            PlayerPrefs.SetInt("MejoraTraje", item2);  
            PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
            PlayerPrefs.SetInt("ChooseItem2", chooseItem2);

            PlayerPrefs.Save();
        }
        if (item1 == 1)
        {
            
            if (chooseItem1 == 0)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usando";
                //Debug.Log("ITEM 1");
                
                if (item2==1)
                {
                    GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usar";
                }
                chooseItem1 = 1;
                chooseItem2 = 0;
                /*chooseItem2 = 0;
                chooseItem3 = 0;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usar";
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = "Usar";
                */
                PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
                PlayerPrefs.SetInt("ChooseItem2", chooseItem2);
                
                PlayerPrefs.Save();

            }
            

        }
        
    }
    public void BuySuit()
    {
        item2 = PlayerPrefs.GetInt("MejoraTraje");
        chooseItem2 = PlayerPrefs.GetInt("ChooseItem2");
        if (CoinPanel.coinAmount >= 100 && item2 == 0)
        {
            item2 = 1;
            chooseItem1 = 0;
            chooseItem2 = 1;
            GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usando";
            if (item1 == 1)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usar";
            }
          
            CoinPanel.coinAmount = CoinPanel.coinAmount - 100;
            PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
            PlayerPrefs.SetInt("MejoraMoney", item1);
            PlayerPrefs.SetInt("MejoraTraje", item2);
            PlayerPrefs.SetInt("MejoraAtaque", item3);
            PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
            PlayerPrefs.SetInt("ChooseItem2", chooseItem2);
            PlayerPrefs.Save();
        }
        if (item2 == 1)
        {
            if (chooseItem2 == 0)
            {
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usando";
                Debug.Log("ITEM 2");
                

                if (item1 == 1)
                {
                    GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usar";
                }
                chooseItem1 = 0;
                chooseItem2 = 1;
                PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
                PlayerPrefs.SetInt("ChooseItem2", chooseItem2);

                PlayerPrefs.Save();

            }
        }
    }
    /*public void BuyA()
    {
        item3 = PlayerPrefs.GetInt("MejoraAtaque");
        if (CoinPanel.coinAmount >= 100 && item3 == 0)
        {
            item3 = 1;
            PlayerPrefs.SetInt("Nlifes", PlayerController.numberLifes);
            PlayerPrefs.SetInt("Nattacks", PlayerController.ammo);
            PlayerPrefs.SetInt("Nairs", AirPanel.airRate);
            CoinPanel.coinAmount = CoinPanel.coinAmount - 100;
            PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
            PlayerPrefs.SetInt("ExcesLife", UpgradesShop.ExcesLife);
            PlayerPrefs.SetInt("ExcesAttack", UpgradesShop.ExcesAttack);
            PlayerPrefs.SetInt("ExcesAir", UpgradesShop.ExcesAir);
            PlayerPrefs.SetInt("MejoraMoney", item1);
            PlayerPrefs.SetInt("MejoraTraje", item2);
            PlayerPrefs.SetInt("MejoraAtaque", item3);

            PlayerPrefs.Save();
        }
    }
    */
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
}
