using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWallController : MonoBehaviour
{
    [Header("Visuals")]
    public SpriteRenderer sr;        // assign or let Awake auto-find
    public Sprite hotSprite;         // sprite used while hot
    public Sprite cooledSprite;      // sprite used when cooled

    [Header("Colliders")]
    public Collider2D damageCollider; // a trigger that hurts the player while hot
    public Collider2D solidCollider;  // a non-trigger collider (walkable) used when cooled

    [Header("Timing")]
    public float cooledDuration = 4f; // seconds wall stays cooled
    public float respawnImmunity = 0.25f; // small immunity so it doesn't immediately re-trigger

    bool cooling = false;
    float lastChangeTime = -999f;

    void Awake()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();
        // safety: ensure initial visual state = hot
        if (sr != null && hotSprite != null) sr.sprite = hotSprite;

        // ensure colliders initial states
        if (damageCollider != null) damageCollider.enabled = true;
        if (solidCollider != null) solidCollider.enabled = false;
    }

    // call this to cool the wall (e.g., from Vent when hit)
    public void CoolNow()
    {
        if (cooling) return;
        StartCoroutine(CoolCoroutine());
    }

    IEnumerator CoolCoroutine()
    {
        cooling = true;
        lastChangeTime = Time.time;

        // swap visuals
        if (sr != null && cooledSprite != null) sr.sprite = cooledSprite;

        // disable damage, enable solid so player can pass
        if (damageCollider != null) damageCollider.enabled = false;
        if (solidCollider != null) solidCollider.enabled = true;

        // wait while cooled
        yield return new WaitForSeconds(cooledDuration);

        // revert to hot
        if (sr != null && hotSprite != null) sr.sprite = hotSprite;
        if (solidCollider != null) solidCollider.enabled = false;
        if (damageCollider != null) damageCollider.enabled = true;

        // small cooldown window so the orb or debris don't immediately re-trigger
        lastChangeTime = Time.time;
        cooling = false;
    }

    // optional helper: safe trigger that ignores calls right after revert (if you wire Vent incorrectly)
    public bool CanTrigger()
    {
        return (Time.time - lastChangeTime) > respawnImmunity && !cooling;
    }
}
