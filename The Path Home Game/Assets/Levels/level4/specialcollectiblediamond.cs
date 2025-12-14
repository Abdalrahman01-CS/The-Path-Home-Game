using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialcollectiblediamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Increment score or play sound
            Debug.Log("Collectible picked!");
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
{
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    if (rb != null)
    {
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic; // stops collectible on ground
    }
}

    }
}
