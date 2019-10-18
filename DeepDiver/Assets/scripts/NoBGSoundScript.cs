using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBGSoundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GameObject.Find("Audio"));
    }
}
