using System.Collections;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [Header("References")]
    public Animator animator;            // optional: assign or auto-get
    public Collider2D platformCollider;  // optional: assign or auto-get
    public SpriteRenderer spriteRenderer; // optional: assign or auto-get
    public GameObject brokenPrefab;      // optional: falling pieces prefab (can be null)

    [Header("Timing")]
    public float timeToDisableCollider = 0.35f;  // wait before disabling collider after animation start
    public float timeToDestroy = 3f;             // used if respawn is false (cleanup)
    public bool respawn = true;
    public float respawnDelay = 5f;              // how long until platform returns

    // internal
    bool broken = false;
    Vector3 startPos;
    Quaternion startRot;
    GameObject activeBrokenInstance;

    void Awake()
    {
        // cache start transform
        startPos = transform.position;
        startRot = transform.rotation;

        // auto-get components if not assigned
        if (animator == null) animator = GetComponent<Animator>();
        if (platformCollider == null) platformCollider = GetComponent<Collider2D>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (broken) return;
        if (!coll.collider.CompareTag("Player")) return;

        // ensure player is landing from above
        foreach (ContactPoint2D contact in coll.contacts)
        {
            if (contact.normal.y < -0.5f)
            {
                StartCoroutine(DoBreakSequence());
                break;
            }
        }
    }

    IEnumerator DoBreakSequence()
    {
        broken = true;

        // trigger the crack/break animation (if any)
        if (animator != null)
            animator.SetTrigger("Crack");

        // wait a short time (allow the animation to start)
        yield return new WaitForSeconds(timeToDisableCollider);

        // disable collider so player falls through
        if (platformCollider != null)
            platformCollider.enabled = false;

        // spawn broken pieces or hide sprite
        if (brokenPrefab != null)
        {
            // instantiate falling pieces at the platform position
            activeBrokenInstance = Instantiate(brokenPrefab, transform.position, transform.rotation);
            // hide the platform image
            if (spriteRenderer != null) spriteRenderer.enabled = false;
        }
        else
        {
            // simply hide the sprite
            if (spriteRenderer != null) spriteRenderer.enabled = false;
        }

        // if not respawning, destroy after timeToDestroy
        if (!respawn)
        {
            Destroy(gameObject, timeToDestroy);
            yield break;
        }

        // respawn after delay
        yield return new WaitForSeconds(respawnDelay);

        // cleanup broken pieces if any
        if (activeBrokenInstance != null)
            Destroy(activeBrokenInstance);

        // reset transform/physics if needed
        transform.position = startPos;
        transform.rotation = startRot;

        // restore sprite and collider
        if (spriteRenderer != null) spriteRenderer.enabled = true;
        if (platformCollider != null) platformCollider.enabled = true;

        // reset animator state
        if (animator != null)
        {
            animator.Play("IdleP", 0, 0f);
            animator.ResetTrigger("Crack");
        }

        broken = false;
    }

    // Optional method if you prefer animation events to call the actual break instantly
    // You can add an Animation Event that calls this method at the frame you want the platform to drop.
    public void OnBreakNow()
    {
        if (broken) return;
        StartCoroutine(DoBreakSequence());
    }
}
