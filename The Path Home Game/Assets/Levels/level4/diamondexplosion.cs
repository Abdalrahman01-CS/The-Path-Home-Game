using System.Collections;
using UnityEngine;

public class diamondexplosion : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool hasExploded = false;

    public Sprite exploded;
    public GameObject CollectibleDiamond;
    public float explosionDelay = 0.6f;
    public float explosionForce = 6f;
    public AudioClip explosionSound;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasExploded && collision.gameObject.CompareTag("Player"))
        {
            hasExploded = true;
            Explode(collision.gameObject);
        }
    }

    void Explode(GameObject player)
    {
        sr.sprite = exploded;

        if (explosionSound != null)
            Audiomanager.Instance.PlayMusicSFX(explosionSound);

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 pushDir = ((Vector2)player.transform.position - (Vector2)transform.position).normalized + Vector2.up;
            rb.AddForce(pushDir * explosionForce, ForceMode2D.Impulse);
        }

        // Spawn collectible immediately for testing
        if (CollectibleDiamond != null)
        {
            Instantiate(CollectibleDiamond, transform.position, Quaternion.identity);
            Debug.Log("Collectible spawned!");
        }

        Destroy(gameObject, explosionDelay);
    }
}
