using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirajController : MonoBehaviour
{
    public Transform Rin;
    public Vector3 offset = new Vector3(1.3f, 1.3f, 0f);
    public float followSpeed = 3f;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 targetPos = Rin.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, targetPos);
        anim.SetBool("isMoving", distance > 0.1f);
    }
}
