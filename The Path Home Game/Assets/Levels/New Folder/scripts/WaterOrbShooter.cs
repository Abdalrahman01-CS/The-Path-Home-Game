using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOrbShooter : MonoBehaviour
{
    public GameObject waterOrbPrefab; 
    public Transform shootPoint;
    public float orbSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Press E to throw
        {
            ShootOrb();
        }
    }

    void ShootOrb()
    {
        GameObject orb = Instantiate(waterOrbPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = orb.GetComponent<Rigidbody2D>();

        // Throw direction (depends on where player is facing)
        float direction = GetComponent<SpriteRenderer>().flipX ? -1 : 1;
        rb.velocity = new Vector2(direction * orbSpeed, 0);
    }
}