using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentActivator : MonoBehaviour
{
    public GameObject cooledPlatform;  // assign in inspector
    public float activeTime = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WaterOrb"))
        {
            StartCoroutine(ActivatePlatform());
        }
    }

    IEnumerator ActivatePlatform()
    {
        cooledPlatform.SetActive(true);
        yield return new WaitForSeconds(activeTime);
        cooledPlatform.SetActive(false);
    }
}