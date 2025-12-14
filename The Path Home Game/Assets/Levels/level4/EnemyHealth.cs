using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public int maxHealth = 3;
    private int current;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        current = maxHealth;
        sr = GetComponent<SpriteRenderer>();

        if (sr == null)
            Debug.LogError("No SpriteRenderer found!");
    }

    public void TakeDamage(int amount)
    {
        current -= amount;
        if (current <= 0)
        {
            Die();
        }
        else
        {
            // Start flicker when damaged
            StartFlicker(0.2f); // 0.2 seconds flicker
        }
    }

    void Die()
    {
        
        Destroy(gameObject);
    }
    public void StartFlicker(float duration)
    {
        StartCoroutine(Flicker(duration));
    }

    private IEnumerator Flicker(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            sr.enabled = !sr.enabled;   // toggle sprite visibility
            timer += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        sr.enabled = true; // make sure sprite is visible at the end
    }
}
