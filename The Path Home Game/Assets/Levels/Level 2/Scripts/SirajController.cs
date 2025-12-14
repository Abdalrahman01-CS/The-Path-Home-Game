using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirajController : MonoBehaviour
{
    public Transform Rin;
    public Vector2 offset = new Vector2(1.3f, 1.3f);
    public float followSpeed = 5f;

    private SpriteRenderer sr;
    private Rigidbody2D RinRb;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        RinRb = Rin.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = (Vector2)Rin.position + offset;
        transform.position = Vector2.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        float distance = Vector2.Distance(transform.position, targetPos);
        anim.SetBool("isMoving", distance > 0.1f);

        if (RinRb.velocity.x > 0.1f)
            sr.flipX = false; 

        else if (RinRb.velocity.x < -0.1f)
            sr.flipX = true;  
    }
}
