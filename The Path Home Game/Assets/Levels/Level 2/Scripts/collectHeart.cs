using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectHeart : MonoBehaviour
{

    public AudioClip heartSound;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Bobby")
        {
            PlayerStats.lives++;
            PlayerStats.hasHeart = true;
            AudioManager.Instance.PlayMusicSFX(heartSound);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
