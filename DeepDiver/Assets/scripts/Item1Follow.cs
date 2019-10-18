using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1Follow : MonoBehaviour {
    public Transform target;
  
    public GameObject playerSprite;
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetInt("ChooseItem1") == 1)
        {
            gameObject.SetActive(true);
        }else
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update() {

        transform.position = target.position;

    }
    /*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Coins"))
        {

            Destroy(col.gameObject);
        }
        
    }
    */
}
