using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    private Camera cam;

    public float targetZoom = 3;

    private float resizeData;

    public float zoomSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        resizeData =  Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= resizeData;

        targetZoom = Mathf.Clamp(targetZoom, 3, 6);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
    }
}
