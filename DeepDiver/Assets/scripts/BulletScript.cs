using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float velX = 0f;
    private float velY = -15f;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

		
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 1f);
	}
}
