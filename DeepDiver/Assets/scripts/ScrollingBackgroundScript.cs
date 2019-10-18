using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundScript : MonoBehaviour {


    private Transform cameraTransform;
    private Transform[] layers;
    private bool first;

    private int topIndex;
    private int bottomIndex;

    public float bgHeight;
    public float parallaxSpeed;
    private float lastCameraY;

    private void Start()
    {

        cameraTransform = Camera.main.transform;
        lastCameraY = cameraTransform.position.y;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++){
            layers[i] = transform.GetChild(i);
        }
        topIndex = 0;
        bottomIndex = layers.Length-1;
        first = true;



    }

    private void ScrollDown()
    {
        Debug.Log(layers[bottomIndex].position);
        if (first)
        {
            layers[topIndex].position = layers[topIndex].position - (Vector3.up * (layers[bottomIndex].position.y - bgHeight));
            layers[topIndex].position = layers[topIndex].position - Vector3.up*(layers[topIndex].position.y*2 - bgHeight);
            first = false;
        }
        else {
            layers[topIndex].position = layers[topIndex].position + (Vector3.up * (layers[bottomIndex].position.y - bgHeight)) - Vector3.up * layers[topIndex].position.y;
        }
        //Debug.Log(layers[topIndex].position);
        bottomIndex = topIndex;
        topIndex++;
        if (topIndex == layers.Length) {
            topIndex = 0;
        }
    }


    private void Update()
    {
        float deltaY = cameraTransform.position.y - lastCameraY;
        transform.position += Vector3.up * (deltaY * parallaxSpeed);
        lastCameraY = cameraTransform.position.y;

        if (cameraTransform.position.y <= (layers[bottomIndex].transform.position.y)) {
            ScrollDown();
        }
    }
}
