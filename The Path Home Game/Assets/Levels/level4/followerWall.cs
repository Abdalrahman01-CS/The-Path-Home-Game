using UnityEngine;

public class followerWall : Enemycontroller
{
    public Transform player;
    public bool isMoving = false;

    void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                maxSpeed * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // DAMAGE PLAYER
        if (other.CompareTag("Player") && CompareTag("DamagingWall"))
        {
            RinStats stats = other.GetComponent<RinStats>();
            if (stats != null)
            {
                stats.TakeDamage(damage);
            }
        }

        // START MOVING
        if (other.CompareTag("Player") && CompareTag("MoveTrigger"))
        {
            isMoving = true;
        }
    }
}
