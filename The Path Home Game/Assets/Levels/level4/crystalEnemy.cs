using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalEnemy : Enemycontroller
{
    public float followSpeed = 2f;

    public GameObject projectilePrefab;   // your crystal projectile prefab
    public Transform shootPoint;          // where the projectile spawns
    public float shootForce = 5f;
    public float shootInterval = 2f;

    private Transform player;
    private float shootTimer = 0f;
    //private SpriteRenderer sr;
    private Animator animator;

    void Start()
    {
     player = GameObject.FindGameObjectWithTag("Player")?.transform;
    // assign SpriteRenderer from parent
    if (sr == null)
        sr = GetComponent<SpriteRenderer>();

    animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        FollowPlayer();
        HandleShooting();
        UpdateShootPoint();
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            followSpeed * Time.deltaTime
        );

        if (player.position.x > transform.position.x)
    sr.flipX = false;
else
    sr.flipX = true;

    }
void HandleShooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            ShootCrystal();
            shootTimer = 0f;
        }
    }
    // This function is called by the animation event
   public void ShootCrystal()
{
    if (projectilePrefab == null || shootPoint == null || player == null) return;

    // Instantiate projectile
    GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

    // Tell projectile to move toward player
    projectile.GetComponent<crystalball>().Initialize(player.position);

    // Play shooting animation
    if (animator != null)
        animator.SetTrigger("Shoot");
}


    // DO NOT override and DO NOT call the parent
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            RinStats playerStats = other.GetComponent<RinStats>();
            if(playerStats != null)
                playerStats.TakeDamage(1);
        }
    }
   void UpdateShootPoint()
    {
        if (sr.flipX)
            shootPoint.localPosition = new Vector3(-Mathf.Abs(shootPoint.localPosition.x), shootPoint.localPosition.y, 0);
        else
            shootPoint.localPosition = new Vector3(Mathf.Abs(shootPoint.localPosition.x), shootPoint.localPosition.y, 0);
    }

    //void OnTriggerEnter2D(Collider2D other){
        //if(other.tag == "Player"){
            //FindObjectOfType<RinStats>().TakeDamage(damage);
            //Flip();
        //}
    //}
}
