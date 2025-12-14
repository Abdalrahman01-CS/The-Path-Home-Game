using UnityEngine;

public class PoisonDiamond : MonoBehaviour
{
    public bool isCollectible = false;       // Poison = false, collectible = true
    public int damageAmount = 1;
    public float rotationSpeed = 200f;
    public AudioClip collect;                // Sound for collectible

    private Rigidbody2D rb;
    private bool onGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotate poisonous diamonds
        if (!isCollectible)
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;

        // Player collects the collectible diamond
        if (isCollectible && other.CompareTag("Player"))
        {
            // Update the UI
            DiamondUI ui = FindObjectOfType<DiamondUI>();
            if (ui != null)
                ui.CollectDiamond();

            // Decrease global diamond count
            if (Diamond.diamonds > 0)
                Diamond.diamonds--;

            // Play sound
            if (collect != null)
                Audiomanager.Instance.PlayMusicSFX(collect);

            Destroy(gameObject);
            return;
        }

        // Poison hits player
        if (!isCollectible && other.CompareTag("Player"))
        {
            RinStats stats = other.GetComponent<RinStats>();
            if (stats != null)
                stats.TakeDamage(damageAmount);

            Destroy(gameObject);
            return;
        }

        // Poison hits ground
        if (!isCollectible && other.CompareTag("Ground"))
        {
            Destroy(gameObject);
            return;
        }

        // Collectible stops on ground
        if (isCollectible && other.CompareTag("Ground") && !onGround)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic; // stops collectible on ground
            onGround = true;
        }
    }
}
