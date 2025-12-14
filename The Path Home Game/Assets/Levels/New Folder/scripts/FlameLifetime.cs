using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameLifetime : MonoBehaviour
{
    public float lifetime = 0.6f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}