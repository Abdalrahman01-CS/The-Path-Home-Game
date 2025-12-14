using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageOnTrigger : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats ps = collision.GetComponent<PlayerStats>();
            if (ps != null)
            {
                ps.TakeDamage(damage);
            }
        }
    }
}
