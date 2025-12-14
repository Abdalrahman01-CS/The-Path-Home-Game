using UnityEngine;
using System.Collections;

public class FireburstTrap : MonoBehaviour
{
    public GameObject flamePrefab;
    public Transform spawnPoint;

    public float interval = 2.5f;
    public float preWarning = 0.4f;
    public float flameDuration = 0.6f;

    public SpriteRenderer crackSR;
    public Color normalColor = Color.white;
    public Color glowColor = new Color(1f, 0.6f, 0.2f);

    void Start()
    {
        if (crackSR == null) crackSR = GetComponent<SpriteRenderer>();
        StartCoroutine(BurstLoop());
    }

    IEnumerator BurstLoop()
    {
        while (true)
        {
            // Wait before glow
            yield return new WaitForSeconds(interval - preWarning);

            // Glow
            crackSR.color = glowColor;

            // Wait during glow
            yield return new WaitForSeconds(preWarning);

            // Spawn fire
            GameObject flame = Instantiate(flamePrefab, spawnPoint.position, Quaternion.identity);
            Destroy(flame, flameDuration);

            // Reset crack color
            crackSR.color = normalColor;
        }
    }
}
