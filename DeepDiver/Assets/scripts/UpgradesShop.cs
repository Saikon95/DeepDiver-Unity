using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesShop : MonoBehaviour {

    public static bool buyed = false;
    public static int ExcesLife;
    public static int ExcesAttack;
    public static int ExcesAir;

    public Text actualLife;
    public Text actualAttack;
    public Text actualAir;
    public Text actualPriceLife;
    public Text actualPriceAttacks;
    public Text actualPriceAir;

    public GameObject imageLives;
    public GameObject imageAttack;
    public GameObject imageAir;
    public int priceLifes;
    public int priceAttack;
    public int priceAir;
    public int compraAir=0;
 

    // Use this for initialization
    void Start () {
        actualLife.text = string.Concat("Actual: ", PlayerController.numberLifes.ToString());
        actualAttack.text = string.Concat("Actual: ", PlayerController.ammo.ToString());
        actualAir.text = string.Concat("Actual: ", ExcesAir.ToString());
        comprobarPrecio();
        

    }
    public void comprobarPrecio()
    {
        switch (PlayerController.numberLifes)
        {
            case 3:
                priceLifes = 15;
                break;
            case 4:
                priceLifes = 30;
                break;
            case 5:
                priceLifes = 60;
                break;

        }
        switch (PlayerPrefs.GetInt("Nattacks"))
        {
            case 3:
                priceAttack = 15;
                break;
            case 4:
                priceAttack = 30;
                break;
            case 5:
                priceAttack = 60;
                break;

        }
        switch (ExcesAir)
        {
            case 0:
                priceAir = 15;
                break;
            case 1:
                priceAir = 30;
                break;
            case 2:
                priceAir = 60;
                break;

        }
        actualPriceLife.text = string.Concat("Precio: ", priceLifes);
        actualPriceAttacks.text = string.Concat("Precio: ", priceAttack);
        actualPriceAir.text = string.Concat("Precio: ", priceAir);
        //Debug.Log("PRECIO VIDAS:" + priceLifes);
        //Debug.Log("PRECIO ATAQUES:" + priceAttack);
        //Debug.Log("PRECIO AIRE:" + priceAir);
        //Debug.Log("AIRE:" + PlayerPrefs.GetInt("Nairs"));
    }
    public void BuyLifes()
    {
        
        if (ExcesLife < 3 && CoinPanel.coinAmount>= priceLifes)
        {
            PlayerController.numberLifes = PlayerController.numberLifes + 1;
            actualLife.text = string.Concat("Actual: ", PlayerController.numberLifes.ToString());

            PlayerPrefs.SetInt("Nlifes", PlayerController.numberLifes);
            PlayerPrefs.SetInt("Nattacks", PlayerController.ammo);
            PlayerPrefs.SetInt("Nairs", AirPanel.airRate);
            CoinPanel.coinAmount = CoinPanel.coinAmount - priceLifes;
            PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);

            buyed = true;
            PlayerPrefs.SetInt("buyed", buyed ? 1 : 0);

            ExcesLife = ExcesLife + 1;
            PlayerPrefs.SetInt("ExcesLife", ExcesLife);
            PlayerPrefs.SetInt("MejoraMoney", ItemShop.item1);
            PlayerPrefs.SetInt("MejoraTraje", ItemShop.item2);
            PlayerPrefs.SetInt("MejoraMoney", ItemShop.item3);
            PlayerPrefs.Save();

            imageLives.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            comprobarPrecio();

        }

    }

    public void BuyAttacks()
    {
        
        if (ExcesAttack < 3 && CoinPanel.coinAmount >= priceAttack)
        {
            PlayerController.ammo = PlayerController.ammo + 1;
            actualAttack.text = string.Concat("Actual: ", PlayerController.ammo.ToString());

            PlayerPrefs.SetInt("Nlifes", PlayerController.numberLifes);
            PlayerPrefs.SetInt("Nattacks", PlayerController.ammo);
            PlayerPrefs.SetInt("Nairs", AirPanel.airRate);
            buyed = true;
            PlayerPrefs.SetInt("buyed", buyed ? 1 : 0);

            ExcesAttack = ExcesAttack + 1;
            PlayerPrefs.SetInt("ExcesAttack", ExcesAttack);
            CoinPanel.coinAmount = CoinPanel.coinAmount - priceAttack;
            PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
            PlayerPrefs.SetInt("MejoraMoney", ItemShop.item1);
            PlayerPrefs.SetInt("MejoraTraje", ItemShop.item2);
            PlayerPrefs.SetInt("MejoraMoney", ItemShop.item3);
            PlayerPrefs.Save();

            imageAttack.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            comprobarPrecio();

        }

    }

    public void BuyAir()
    {
        
        if (ExcesAir < 3 && CoinPanel.coinAmount >= priceAir)
        {

            AirPanel.airRate = AirPanel.airRate - 3;
            //PlayerController.nAir = PlayerController.nAir + 1;
            //actualAir.text = string.Concat("Actual: ", PlayerController.nAir.ToString());
            ExcesAir = ExcesAir + 1;
            actualAir.text = string.Concat("Actual: ", ExcesAir);

            PlayerPrefs.SetInt("Nlifes", PlayerController.numberLifes);
            PlayerPrefs.SetInt("Nattacks", PlayerController.ammo);
            //PlayerPrefs.SetInt("Nairs", PlayerController.nAir);
            PlayerPrefs.SetInt("Nairs", AirPanel.airRate);
            CoinPanel.coinAmount = CoinPanel.coinAmount - priceAir;
            PlayerPrefs.SetInt("Ncoins", CoinPanel.coinAmount);
            buyed = true;
            PlayerPrefs.SetInt("buyed", buyed ? 1 : 0);

           
            PlayerPrefs.SetInt("ExcesAir", ExcesAir);
            PlayerPrefs.SetInt("MejoraMoney", ItemShop.item1);
            PlayerPrefs.SetInt("MejoraTraje", ItemShop.item2);
            PlayerPrefs.SetInt("MejoraMoney", ItemShop.item3);
            PlayerPrefs.Save();

            imageAir.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            comprobarPrecio();

        }

    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
