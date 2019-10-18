using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinPanel : MonoBehaviour {

    public Text coinsLabel;
    public static int coinAmount;


	// Use this for initialization
	void Start () {

        coinsLabel.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        coinsLabel.text = coinAmount.ToString();
	}
}
