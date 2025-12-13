using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{

    AudioSource voiceSource;
    Collider2D soundTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        voiceSource = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D Rin)
    {
        if (Rin.gameObject.tag == "Rin")
            voiceSource.Play();
    }

    void OnTriggerExit2D(Collider2D Rin)
    {
        if (Rin.gameObject.tag == "Rin")
            voiceSource.Stop();
    }
}
