using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;

    public float speed;
    private bool AtoB;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AtoB == true)
        {
            targetPosition = PointA.position;
        }
        else
        {
            targetPosition = PointB.position;
        }


        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.MoveTowards(transform.position.x, targetPosition.x, speed * Time.deltaTime);

        transform.position = newPosition;


        if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.1f)
        {
            AtoB = !AtoB;
        }
    }
}
