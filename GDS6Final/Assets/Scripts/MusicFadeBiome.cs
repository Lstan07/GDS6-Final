using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeBiome : MonoBehaviour
{
    public AudioSource Music;

    public float fadeInFactor = 0.02f;
    public float FadeOutFactor = 0.03f;

    public bool fadeIn = false;
    public bool fadeOut = false;

    void Start()
    {
        Music.volume = 0.0f;
    }


    void Update()
    {
        if (fadeIn)
        {
            if (Music.volume <= 0.1)
            {
                Music.volume += fadeInFactor * Time.deltaTime;
                print("fadeIn");
            }
        }

        if (fadeOut)
        {
            if (Music.volume >= 0)
            {
                Music.volume -= FadeOutFactor * Time.deltaTime;
            }
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (Music.isPlaying == false){
            Music.Play();
        }
       
        if (other.gameObject.CompareTag("Player"))
        {

            fadeIn = true;
            fadeOut = false;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            fadeOut = true;
            fadeIn = false;
            print("why");


        }
    }
}