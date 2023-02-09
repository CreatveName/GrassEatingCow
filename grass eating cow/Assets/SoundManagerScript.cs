using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip goatSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Awake()
    {
        goatSound = Resources.Load<AudioClip>("goat");

            audioSrc = GetComponent<AudioSource> ();
    }


    
    public static void PlaySound(string clip)
    {
        //SoundManagerScript.Playsound ("Sound));         
        switch (clip)
        {
            case "goat":
                audioSrc.PlayOneShot (goatSound);
                break;
        }
    }
}
