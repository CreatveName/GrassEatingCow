using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip goatSound;
    public static AudioClip scoreSound;
    public static AudioClip eatingSound;
    static AudioSource audioSrc;
  
 
    // Start is called before the first frame update
    void Awake()
    {
        scoreSound = Resources.Load<AudioClip>("bell");

        eatingSound = Resources.Load<AudioClip>("eating");

       audioSrc = GetComponent<AudioSource> ();
    }
   
    
    public static void PlaySound(string clip)
    {       
        switch (clip)
        {
            case "bell":
                audioSrc.PlayOneShot (scoreSound);
                break;

            case "eating":
                audioSrc.PlayOneShot(eatingSound);
                break;

        }
    }
}
