using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{

    private SpriteRenderer sr;

    public Sprite explodedBlock; 

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Bobby" && player.GetContact(0).point.y < transform.position.y)
        {
            sr.sprite = explodedBlock;
            Object.Destroy(gameObject, .2f);
        }
    }
}
