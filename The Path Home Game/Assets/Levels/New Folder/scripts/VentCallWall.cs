using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCallWall : MonoBehaviour
{
    public LavaWallController linkedWall;   
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WaterOrb"))
        {
            linkedWall.CoolNow();           // cool the wall
            Destroy(other.gameObject);      // remove the orb
        }
    }
}
