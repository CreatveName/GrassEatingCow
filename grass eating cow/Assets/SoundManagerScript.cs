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

        //dinoSound = Resources.Load<AudioClip>("dinosaur");

        //cowSound = Resources.Load<AudioClip>("cow");

        //mooshroomSound = Resources.Load<AudioClip>("mooshroom");

        //almondSound = Resources.Load<AudioClip>("nut");


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

            //case "dinosaur"
                //audioSrc.PlayOneShot (dinoSound);
                //break;

            //case "cow"
                //audioSrc.PlayOneShot(cowSound);
                //break;

             //case "mooshroom"
                //audioSrc.PlayOneShot(mooshroomSound);
                //break;

             //case "nut"
                //audioSrc.PlayOneShot(almondSound);
                //break;

        }
    }
}
