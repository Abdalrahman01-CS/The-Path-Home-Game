using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; // Empty GameObject where bullets spawn
    public float bulletSpeed = 5f;
    public float shootInterval = 2f;
    public Animator animator;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 1f, shootInterval);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void Shoot()
{
    if (player == null) return;

    // Play shooting animation
    animator.SetTrigger("Shoot");

    Vector2 direction = (player.position - firePoint.position).normalized;
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
}
}
