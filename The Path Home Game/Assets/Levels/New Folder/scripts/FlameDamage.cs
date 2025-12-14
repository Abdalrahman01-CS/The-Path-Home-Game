using UnityEngine;

public class FlameDamage : MonoBehaviour
{
    [Tooltip("How much HP the flame removes on contact")]
    public int damage = 1;

    // Called when the flame's trigger collider overlaps another collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Only react to the player
        if (!other.CompareTag("Player")) return;

        // Try to get PlayerStats on the same GameObject (or parent)
        PlayerStats ps = other.GetComponent<PlayerStats>();
        if (ps == null)
        {
            // try parent in case PlayerStats is on parent object
            ps = other.GetComponentInParent<PlayerStats>();
        }

        if (ps != null)
        {
            ps.TakeDamage(damage);
            // optional: play a sound or VFX here
        }
        else
        {
            Debug.LogWarning("FlameDamage: Player has no PlayerStats component.", other.gameObject);
        }
    }
}
