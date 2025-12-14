using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //If the collider of the object touches the checkpoint's circle collider
            FindObjectOfType<LevelManager>().CurrentCheckpoint = this.gameObject; //update the current checkpoint value in the level manager script
    }

}
