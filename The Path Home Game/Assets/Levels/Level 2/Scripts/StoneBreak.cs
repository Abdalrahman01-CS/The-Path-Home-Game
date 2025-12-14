using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBreak : MonoBehaviour
{

    private SpriteRenderer sr;
    private Collider2D collider;
    private Sprite originalSprite;

    public Sprite explodedStone; 

    public float delay = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalSprite = sr.sprite;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Rin" && player.GetContact(0).point.y > transform.position.y)
        {
            Invoke("BreakStone", delay);
        }
    }

    void BreakStone()
    {
        sr.sprite = explodedStone;
        collider.enabled = false;
    }

    public void ResetStone()
    {
        sr.sprite = originalSprite;
        collider.enabled = true;
    }
}
