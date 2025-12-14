using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingRock : MonoBehaviour
{
    public float moveDistance = 2f;  // how high or low it goes
    public float speed = 2f;         // movement speed
    public bool startMovingUp = true; // true = up first, false = down first

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingUp;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        movingUp = startMovingUp;  
    }

    // Update is called once per frame
    void Update()
    {
         // Decide current target
        if (movingUp)
            targetPos = startPos + Vector3.up * moveDistance;
        else
            targetPos = startPos + Vector3.down * moveDistance;

        // Move rock
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // If reached target → switch direction
        if (Vector3.Distance(transform.position, targetPos) < 0.05f)
         movingUp = !movingUp;
    }
    }

