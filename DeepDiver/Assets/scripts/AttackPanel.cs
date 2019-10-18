using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPanel : MonoBehaviour {

    public GameObject Attack;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setAttack(int nAttacks)
    {
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (var i = 0; i < nAttacks; i++)
        {
            var attack = Instantiate(Attack, transform);
            attack.transform.localPosition = new Vector2(i * 20, 0);
        }
    }
}
