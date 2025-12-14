using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public static int diamonds=4;
    public AudioClip collect;
    public AudioClip lastdiamond;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag == ("Player") && diamonds > 1)
        {
        diamonds--;
        Audiomanager.Instance.PlayMusicSFX(collect);
        Debug.Log("Diamonds left:"+ diamonds);
        Destroy(gameObject);

    }else if(diamonds==1){
        diamonds--;
        Audiomanager.Instance.PlayMusicSFX(lastdiamond);
        Debug.Log("Diamonds left:"+ diamonds);
        Destroy(gameObject);
    }
    }
}
