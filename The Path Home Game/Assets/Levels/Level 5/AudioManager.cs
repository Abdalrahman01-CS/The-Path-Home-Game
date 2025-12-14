using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
//static?? bc whole game will have only 1 instance of audiomanger
public static AudioManager Instance;

    public AudioSource musicSource;//source plays background
   public AudioSource sfxSource;//source plays sound effects

    public AudioClip overworldMusic;//### 
    public AudioClip caveMusic;//####

    public AudioClip[] variousSFX;// arrays of sound effect clips to keep things varied
    void Awake()
    {
        //make sure the entire game only has audio manager throughout 
        if (Instance==null){
            Instance=this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        // background music clip is assigned, and volume starts off 
        musicSource.clip=overworldMusic;
        musicSource.Play();
    }
    //public in case another object needs to call for specific sound to begin playing 
  public void PlayMusicSFX(AudioClip clip)
    {
        sfxSource.clip=clip;
        sfxSource.Play();
    }
    //public in case another object needs to call for a soundtrack to begin playing 
public void PlayMusic(AudioClip clip)
    {
        musicSource.clip=clip;
        musicSource.Play();
    }
//function takes a bunch of sound clips as parameters


public void PlayRandomSFX(params AudioClip[] clips)
    {
        //assign the incoming array of items to our local arraylist variable called 'variousSFX'
        variousSFX=clips;
        //randomly select a sound clip from arraylist 
        int index=Random.Range(0,variousSFX.Length);
        sfxSource.PlayOneShot(variousSFX[index]);
    }   




    // Update is called once per frame
    void Update()
    {
        
    }
}
