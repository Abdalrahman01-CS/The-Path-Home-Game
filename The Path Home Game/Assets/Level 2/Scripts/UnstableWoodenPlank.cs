using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableWoodenPlank : MonoBehaviour
{
    private Vector3 initialPosition;
    public float delay = 2.5f;
    public float mass = 150f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>(); 
        rb.mass = mass;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter2D(Collider2D Rin)
    {
        if (Rin.gameObject.tag == "Rin")
        {
           Invoke("unFreezeYandConstraints", delay); 
        }
    }

    void unFreezeYandConstraints()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void ResetPosition()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = initialPosition;
    }
}
