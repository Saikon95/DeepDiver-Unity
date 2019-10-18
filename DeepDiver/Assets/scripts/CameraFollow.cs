using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    private float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        
        Vector3 desiredPosition = target.position + new Vector3(0, -3, -10);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(-46.0f, smoothedPosition.y, -10.0f);
    }
  
}
