using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class PlaceHoop : MonoBehaviour
{

    public GameObject toPlace;
    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private ARPlaneManager planeManager;

    private GameObject emptyObject;
    private GameObject planeObject;



    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
        emptyObject = new GameObject();
        planeObject = planeManager.planePrefab;

    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if(raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if(spawnedObject == null)
            {
                spawnedObject = Instantiate(toPlace, hitPose.position, hitPose.rotation);
            }
            else
            {
                //spawnedObject.transform.position = hitPose.position;
            }
            // remove planes
            planeManager.enabled = false;

            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
                
                
            }
                
        }
    }

    public void ResetGame()
    {
        Destroy(spawnedObject);
        planeManager.enabled = true;
        foreach (var plane in planeManager.trackables)
        {
            
            plane.gameObject.SetActive(true);
            
        }
    }
}
