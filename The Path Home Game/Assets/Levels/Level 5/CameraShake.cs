using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
public static CameraShake instance;

private Vector3 shakeOffset = Vector3.zero;
    private Vector3 originalPos;

    private void Awake()
    {
        instance = this;
    originalPos = transform.localPosition;
    Debug.Log("CameraShake instance set: " + instance);
    }

    void LateUpdate()
    {
        // Apply shake offset after all other movement (like follow)
        transform.localPosition = shakeOffset;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            shakeOffset = new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        shakeOffset = Vector3.zero;
    }
}
