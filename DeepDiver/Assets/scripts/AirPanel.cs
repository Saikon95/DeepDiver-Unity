using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AirPanel : MonoBehaviour {

    //public GameObject Air;

    public Image airBarEmpty;
    public GameObject Bubbles;
    public static float fullAir = 0f;
    private float emptyAir = 0;
    public static int airRate = 15;
    public static float limitAir = 0f;
    private float plusBubble = 30f;

    public static float airBarX = 0;

    

    // Use this for initialization
    void Start()
    {
        airBarX = airBarEmpty.GetComponent<RectTransform>().anchoredPosition.x;
        fullAir = airBarEmpty.GetComponent<RectTransform>().anchoredPosition.x / 2;
        limitAir = fullAir;
        Bubbles.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (airBarEmpty.GetComponent<RectTransform>().anchoredPosition.x < emptyAir)
        {
            airBarX += airRate * Time.deltaTime; 
            airBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector3(airBarX, 0, 0);
        }
        if (airBarEmpty.GetComponent<RectTransform>().anchoredPosition.x >= emptyAir)
        {
            if (GlobalVariables.ChosenLevel == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 12);
            }
            else
            {
                if (GlobalVariables.ChosenLevel == 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
        if (airBarX > -50)
        {
            Bubbles.SetActive(true);
            
        }
    }

    public void plusAir(Image airBarEmpty)
    {
        limitAir = airBarX - fullAir;
        if (limitAir - plusBubble < fullAir)
        {
            Debug.Log("if");
            airBarX += (fullAir - limitAir);
            airBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector3(airBarX, 0, 0);
        }
        else {
        
            airBarX -= plusBubble;
            airBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector3(airBarX, 0, 0);
        }
    }
    

}
