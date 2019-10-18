using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

   // private float speed = 5;
    public GameObject Bubble;

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);           

    }

    void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.tag.Equals("Bullet")) {
            Instantiate(Bubble, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
           
        }
       /* if (col.gameObject.tag.Equals("wall")) {
            transform.Rotate(new Vector3(0, -180, 0));
        }*/
    }
}
