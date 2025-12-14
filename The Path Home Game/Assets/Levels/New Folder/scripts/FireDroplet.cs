using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDroplet : MonoBehaviour
{
    public int damage = 1;
    public float minSpeed = 2f;   // slowest falling speed
    public float maxSpeed = 6f;   // fastest falling speed
    private float fallSpeed;

    public float lifeTime = 6f;

    void Start()
    {
        fallSpeed = Random.Range(minSpeed, maxSpeed); 
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}


