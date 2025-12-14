using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    public float CameraSpeed;
    public float minX, maxX;
    public float minY, maxY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate(){
    
        if (Target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp((Vector2)transform.position, (Vector2)Target.position, Time.deltaTime * CameraSpeed);
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY,-10f);
        }
    }

}
