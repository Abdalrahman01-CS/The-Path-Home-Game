using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager Instance;
    public AudioSource musicSource; //backgorund music
    public AudioSource sfxSource;   //sound effects
    public AudioClip crystalcave; //audio of background music level 4
    public AudioClip collectClip;   // collect SFX
    public AudioClip endClip;       // end SFX
    //public AudioClip[] variousSFX;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip=crystalcave;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void Awake(){
        if(Instance == null){
            Instance=this;
            DontDestroyOnLoad(gameObject);

        }else Destroy(gameObject);
    }
    public void PlayMusicSFX(AudioClip clip){
        sfxSource.clip=clip;
        sfxSource.Play();
    }
    public void PlayMusic(AudioClip clip){
        musicSource.clip=clip;
        musicSource.Play();
    }
}
