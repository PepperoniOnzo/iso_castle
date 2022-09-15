using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;
    private Vector3 dragOrigin;

    float inputScrollWheel;
    int maxZoom = 10, minZoom = 2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            dragOrigin = camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - camera.ScreenToWorldPoint(Input.mousePosition);
            camera.transform.position += difference;
        }

        inputScrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (inputScrollWheel > 0f && camera.orthographicSize <= maxZoom)
        {
            camera.orthographicSize++;
        }
        else if (inputScrollWheel < 0f && camera.orthographicSize >= minZoom) 
        {
            camera.orthographicSize--;
        }
    }
}
