using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform Target;
    public float CameraSpeed;

    public float minX, maxX, minY, maxY;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Run Every 0.2 SEC
    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector2 camPos = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed);
            Vector2 newCamPos = camPos;

            float clampX = Mathf.Clamp(newCamPos.x, minX, maxX);
            float clampY = Mathf.Clamp(newCamPos.y, minY, maxY);

            transform.position = new Vector3(clampX, clampY, -10);
        }
    }
}
