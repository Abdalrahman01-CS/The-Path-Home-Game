using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public KeyCode spaceBar;
    public KeyCode L;
    public KeyCode R;

    public Transform groundCheck;

    public float groundCheckRadius;

    public LayerMask whatIsGround;

    private bool grounded;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(spaceBar) && grounded)
        {
            Jump();
        }

        if(Input.GetKey(L))
        {
            Vector2 move_L = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            GetComponent<Rigidbody2D>().velocity = move_L;

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if(Input.GetKey(R))
        {
            Vector2 move_R = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            GetComponent<Rigidbody2D>().velocity = move_R;

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("Grounded", grounded);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
