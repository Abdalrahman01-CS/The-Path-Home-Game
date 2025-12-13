using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2CheckpointBoundary : MonoBehaviour
{
    public UnstableWoodenPlank woodenPlank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Rin")
        {
            FindObjectOfType<Level2Manager>().RespawnPlayer();
            woodenPlank.ResetPosition();
        }
    }
}
