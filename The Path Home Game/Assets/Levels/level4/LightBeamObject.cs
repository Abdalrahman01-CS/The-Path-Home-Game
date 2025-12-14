using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamObject : MonoBehaviour
{
    public int damage = 1;
    public float duration = 0.25f;        // how long the beam exists
    public bool damageOverTime = false;   // false => damage on first touch
    public float tick = 0.1f;             // used only if damageOverTime

    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    void OnEnable()
    {
        col = GetComponent<Collider2D>();
    col.isTrigger = true;

    // Immediately check for enemies at the start
    DoDamageOverlap();

    if (damageOverTime) StartCoroutine(DamageTicks());
    else Invoke(nameof(DisableSelf), duration);
    }

    IEnumerator DamageTicks()
    {
        float timer = 0f;
        while (timer < duration)
        {
            DoDamageOverlap();
            timer += tick;
            yield return new WaitForSeconds(tick);
        }
        DisableSelf();
    }

    // Damage enemies on trigger enter (instant)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("crystalenemy"))
        {
            EnemyHealth hp = other.GetComponent<EnemyHealth>();
            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
        }
    }

    void DoDamageOverlap()
    {
        // optional: area damage using overlap box matching collider bounds
        var hits = Physics2D.OverlapBoxAll(transform.position, GetComponent<Collider2D>().bounds.size, transform.eulerAngles.z);
        foreach (var h in hits)
        {
            if (h != null && h.CompareTag("crystalenemy"))
                TryDamage(h.gameObject);
        }
    }

    void TryDamage(GameObject target)
    {
        var dmg = target.GetComponent<IDamageable>();
        if (dmg != null) { dmg.TakeDamage(damage); return; }

        // fallback: call TakeDamage by name if present
        target.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
    }

    void DisableSelf()
    {
        Destroy(gameObject); // or set inactive if pooled
    }
}
