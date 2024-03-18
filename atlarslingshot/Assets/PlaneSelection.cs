using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PlaneSelection : MonoBehaviour
{
    ARRaycastManager raycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (raycastManager.Raycast(ray, hits, TrackableType.PlaneWithinPolygon))
            {
                // this wiill select the first detected plane
                ARPlane plane = hits[0].trackable as ARPlane;
                
                // this will perform actions on the selected plane
                HandlePlaneSelection(plane);
            }
        }
    }

    void HandlePlaneSelection(ARPlane plane)
    {
        // Perform actions when a plane is selected
        Debug.Log("Plane selected: " + plane.gameObject.name);
    }
}