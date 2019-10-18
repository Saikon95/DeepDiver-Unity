using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChooseItems : MonoBehaviour
{
    public static int chooseItem1;
    public static int chooseItem2;
    public static int chooseItem3;

    public static int item1;
    public static int item2;
    public static int item3;

    // Use this for initialization
    void Start()
    {
        chooseItem1 = PlayerPrefs.GetInt("ChooseItem1");
        chooseItem2 = PlayerPrefs.GetInt("ChooseItem2");
        chooseItem3 = PlayerPrefs.GetInt("ChooseItem3");

        if (chooseItem1 == 1)
        {
            GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usando";
        }
        if (chooseItem2 == 1)
        {
            GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usando";
        }
        if (chooseItem3 == 1)
        {
            GameObject.Find("Button3").GetComponentInChildren<Text>().text = "Usando";
        }
    }



    public void Choose1()
    {
        chooseItem1 = PlayerPrefs.GetInt("ChooseItem1");
        item1 = PlayerPrefs.GetInt("MejoraMoney");
        if (item1 == 1)
        {
            if (chooseItem1 == 0)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Dejar";
                Debug.Log("ITEM 1");
                chooseItem1 = 1;
                chooseItem2 = 0;
                chooseItem3 = 0;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usar";
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = "Usar";
                PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
                PlayerPrefs.SetInt("ChooseItem2", chooseItem2);
                PlayerPrefs.SetInt("ChooseItem3", chooseItem3);
                PlayerPrefs.Save();

            }
            else
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usar";
                chooseItem1 = 0;
                PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
                PlayerPrefs.SetInt("ChooseItem2", chooseItem2);
                PlayerPrefs.SetInt("ChooseItem3", chooseItem3);
                PlayerPrefs.Save();
            }

        }

    }

    public void Choose2()
    {
        chooseItem2 = PlayerPrefs.GetInt("ChooseItem2");
        item2 = PlayerPrefs.GetInt("MejoraTraje");
        if (item2 == 1)
        {
            if (chooseItem2 == 0)
            {
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Dejar";
                Debug.Log("ITEM 2");
                chooseItem1 = 0;
                chooseItem2 = 1;
                chooseItem3 = 0;
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usar";
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = "Usar";
                PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
                PlayerPrefs.SetInt("ChooseItem2", chooseItem2);
                PlayerPrefs.SetInt("ChooseItem3", chooseItem3);
                PlayerPrefs.Save();

            }
            else
            {
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usar";
                chooseItem2 = 0;
                PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
                PlayerPrefs.SetInt("ChooseItem2", chooseItem2);
                PlayerPrefs.SetInt("ChooseItem3", chooseItem3);
                PlayerPrefs.Save();
            }

        }
    }
    public void Choose3()
    {
        chooseItem3 = PlayerPrefs.GetInt("ChooseItem3");
        item3 = PlayerPrefs.GetInt("MejoraAtaque");
        Debug.Log("ITEM 3" + item3);
        if (item3 == 1)
        {
            if (chooseItem3 == 0)
            {
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = "Dejar";
                Debug.Log("ITEM 3");
                chooseItem1 = 0;
                chooseItem2 = 0;
                chooseItem3 = 1;
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Usar";
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Usar";
                PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
                PlayerPrefs.SetInt("ChooseItem2", chooseItem2);
                PlayerPrefs.SetInt("ChooseItem3", chooseItem3);
                PlayerPrefs.Save();

            }
            else
            {
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = "Usar";
                chooseItem3 = 0;
                PlayerPrefs.SetInt("ChooseItem1", chooseItem1);
                PlayerPrefs.SetInt("ChooseItem2", chooseItem2);
                PlayerPrefs.SetInt("ChooseItem3", chooseItem3);
                PlayerPrefs.Save();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);
    }
}
