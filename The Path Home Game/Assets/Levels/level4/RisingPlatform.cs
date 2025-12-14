using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

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
        if(AtoB == true){
            targetPosition = pointA.position;
        }
        else{
            targetPosition = pointB.position;
        }

        //move towars target position on y-axis
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.MoveTowards(transform.position.y, targetPosition.y, speed * Time.deltaTime);
        transform.position = newPosition;

        if(Mathf.Abs(transform.position.y - targetPosition.y)< 0.1f){
            AtoB = !AtoB; // if true, become false. And vice versa.
        }
    }
    // to make the charachter sit still on the platform, we make her a child as she stands on it
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.transform.SetParent(transform);// make the platform a parent
        }
    }
    // the moment the character jumps, he is no longer a child of the platform
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.transform.SetParent(null);// make the platform a non parent
        }
    }

}
