using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{

    public float maxSpeed;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void FixedUpdate()
    {
        if(true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }

        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Bobby")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            
        }
    }
}
