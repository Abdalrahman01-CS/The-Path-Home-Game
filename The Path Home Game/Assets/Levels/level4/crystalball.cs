using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalball : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public float lifeTime = 3f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    // Initialize direction toward target
    public void Initialize(Vector2 targetPosition)
    {
        moveDirection = (targetPosition - (Vector2)transform.position).normalized;

        rb = GetComponent<Rigidbody2D>();
        if(rb != null)
            rb.velocity = moveDirection * speed;

        // Optional: flip sprite if needed
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if(sr != null)
            sr.flipX = moveDirection.x < 0;
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RinStats playerStats = other.GetComponent<RinStats>();
            if (playerStats != null)
                playerStats.TakeDamage(damage);

            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
