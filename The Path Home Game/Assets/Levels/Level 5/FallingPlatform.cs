using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
 [Header("Timings")]
    public float warningDuration = 0.5f; // duration of the warning shake/flash
    public float fallDelay = 0.3f;       // small delay before fall
    public float respawnDelay = 2f;      // time until platform returns

    [Header("Fall Settings")]
    public float fallSpeed = 4f;
    public float respawnMoveSpeed = 3f;

    [Header("Flash Settings")]
    public Color flashColor = Color.red;
    public float flashSpeed = 10f;

    [Header("Shake Settings")]
    public float shakeIntensity = 0.05f; // warning shake of platform

    [Header("Particles & Sounds")]
    public ParticleSystem dustEffect;
    public AudioSource shakeSound;
    public AudioSource fallSound;

    // Internal variables
    private Vector3 originalPos;
    private bool isFalling = false;
    private bool isRespawning = false;
    private SpriteRenderer sr;

    void Start()
    {
        originalPos = transform.position;
        sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.color = Color.white;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFalling && collision.collider.CompareTag("Player"))
        {
            StartCoroutine(WarningAndFall());
        }
    }

    private IEnumerator WarningAndFall()
    {
        isFalling = true;

        // Play shake sound during warning
        if (shakeSound != null) shakeSound.Play();

        // Optional: trigger camera shake slightly during warning
        if (CameraShake.instance != null)
            StartCoroutine(CameraShake.instance.Shake(warningDuration, 0.05f));

        // Warning shake + flash
        float timer = 0f;
        while (timer < warningDuration)
        {
            // Flash
            if (sr != null)
            {
                float t = Mathf.PingPong(Time.time * flashSpeed, 1f);
                sr.color = Color.Lerp(Color.white, flashColor, t);
            }

            // Small shake
            float x = Random.Range(-shakeIntensity, shakeIntensity);
            float y = Random.Range(-shakeIntensity, shakeIntensity);
            transform.position = originalPos + new Vector3(x, y, 0f);

            timer += Time.deltaTime;
            yield return null;
        }

        // Reset color and position
        if (sr != null) sr.color = Color.white;
        transform.position = originalPos;

        // Wait a little before fall
        yield return new WaitForSeconds(fallDelay);

        // Play dust and fall sound
        if (dustEffect != null) dustEffect.Play();
        if (fallSound != null) fallSound.Play();

        // Trigger strong camera shake during fall
        if (CameraShake.instance != null)
            StartCoroutine(CameraShake.instance.Shake(0.3f, 0.15f));

        // FALL – move down manually
        while (transform.position.y > originalPos.y - 10f)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
            yield return null;
        }

        // Wait before respawn
        yield return new WaitForSeconds(respawnDelay);

        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        isRespawning = true;

        Vector3 hiddenPos = originalPos + Vector3.down * 10f;
        transform.position = hiddenPos;

        // Move smoothly back to original position
        while (Vector3.Distance(transform.position, originalPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, respawnMoveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = originalPos;
        isFalling = false;
        isRespawning = false;
    }
}
