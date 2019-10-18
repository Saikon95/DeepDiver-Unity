using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLife : MonoBehaviour {
    public GameObject blueHeart;
    public int bluelifes = 3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setHealth(int nLives)
    {
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (var i = 0; i < nLives; i++)
        {
            Debug.Log("ENTRAAAA");
            var blueheart = Instantiate(blueHeart, transform);
            blueheart.transform.localPosition = new Vector2(50 + i * 100, 0);


        }
    }

}
