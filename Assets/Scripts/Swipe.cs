using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//code taken from https://www.youtube.com/watch?v=7O9bAFyGvH8
public class Swipe : MonoBehaviour
{
    private Vector2 startPos, endPos, diection;
    private float touchTimeStart, touchTimeFinish, timeInterval;


    [SerializeField]
    private float throwForceXandY = 1f;

    [SerializeField]
    private float throwForceZ = 50f;

    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;

            timeInterval = touchTimeFinish - touchTimeStart;

            endPos = Input.GetTouch(0).position;

            diection = startPos - endPos;

            rb.isKinematic = false;
            rb.AddForce(-diection.x * throwForceXandY, -diection.y * throwForceXandY, throwForceZ / timeInterval);

            Destroy(gameObject, 3);


        }

    }

}
