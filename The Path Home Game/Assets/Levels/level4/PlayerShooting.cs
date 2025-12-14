using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject beamPrefab;
    public Transform firePoint;
    public KeyCode fireKey = KeyCode.Mouse0;
    public float fireRate = 0.25f; // seconds between beam spawns
    private float fireCooldown = 0f;
    public LayerMask enemyLayer;
    public int damage = 1;
    public float maxBeamLength = 10f;
    //public float beamLength = 8f; // optional: scale beam to length
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;

    if (Input.GetKey(fireKey) && fireCooldown <= 0f)
    {
        FireBeam();
        fireCooldown = fireRate;
    }
    }
    void FireBeam()
    {
        // 1) Choose direction based on player flip
    bool facingLeft = GetComponent<SpriteRenderer>().flipX;

    Vector3 rot = facingLeft ? 
                  new Vector3(0, 180, 0) :   // flip beam horizontally 
                  new Vector3(0, 0, 0);

    // 2) Spawn rotated beam
    Instantiate(beamPrefab, firePoint.position, Quaternion.Euler(rot));
    }
}
