using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PlaneSelection : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
            {
                // this will select the first detected plane
                ARPlane plane = hits[0].trackable as ARPlane;
                
                // this will perform actions on the selected plane
                HandlePlaneSelection(plane);
            }
        }
    }

    void HandlePlaneSelection(ARPlane plane)
    {
        // this performs actions when a plane is selected
        Debug.Log("Plane selected: " + plane.gameObject.name);
    }
}