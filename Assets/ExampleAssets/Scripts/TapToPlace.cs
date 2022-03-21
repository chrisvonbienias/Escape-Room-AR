using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placableObjects;

    [SerializeField]
    private GameObject placementMenu;

    public Text text;

    private int index = 0;
    private Dictionary<string, GameObject> placedObjects = new Dictionary<string, GameObject>();

    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();

        foreach(GameObject prefab in placableObjects)
        {
            GameObject newObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newObject.name = prefab.name;
            newObject.SetActive(false);
            placedObjects.Add(prefab.name, newObject);
        }
        spawnedObject = placedObjects["chest"];
        text.text = spawnedObject.name;
    }

    private void Update()
    {
        if (!placementMenu.activeInHierarchy)
        {
            return;
        }

        if(!GetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if(raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            hitPose.rotation = Quaternion.Euler(hitPose.rotation.eulerAngles.x, hitPose.rotation.eulerAngles.y, 0);

            spawnedObject = placedObjects[placableObjects[index].name];
            spawnedObject.SetActive(true);
            spawnedObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
        }
        text.text = spawnedObject.name;
        
    }

    bool GetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (!IsPointerOverUIObject())
            {
                touchPosition = touch.position;
                return true;
            }
        }

        touchPosition = default;
        return false;
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void NextObject()
    {
        if(index == placableObjects.Length - 1)
        {
            return;
        }

        index++;
        text.text = spawnedObject.name;
    }
    public void PreviousObject()
    {
        if (index == 0)
        {
            return;
        }

        index--;
        text.text = spawnedObject.name;
    }
}
