using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera Cam; 
    public float TargetZoom = 3; //Value of zooming
    private float ScrollData;
    public float ZoomSpeed = 3; //Speed of zooming process (in/out)
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>();
        TargetZoom = Cam.orthographicSize; //The game will begin with the TargetZoom assigned the default given camera size
    }


    // Update is called once per frame
    void Update()
    {
        ScrollData = Input.GetAxis("Mouse ScrollWheel");
        //When the mouse's scrollweheel is not moving, this function returns zero.
        //When the mouse's scrollweheel is moving forward, this function returns a positive value.
        //When the mouse's scrollweheel is moving backward, this function returns negative value.

        //Updating the TargetZoom to change from the default value to whichever scrolling up or down
        TargetZoom = TargetZoom - ScrollData;

        //Set limits to avoid zooming in/out too much
        TargetZoom = Mathf.Clamp(TargetZoom, 3, 6);

        //Lerp function is used to smooth the transition from size 1 to size 2
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
    }
}
