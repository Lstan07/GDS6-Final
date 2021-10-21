using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeBiome : MonoBehaviour
{
    public AudioSource Music;

    public float fadeInFactor = 0.015f;
    public float fadeOutFactor = 0.03f;

    public bool fadeIn = false;
    public bool fadeOut = false;

    public AudioClip MarketMusic;
    public AudioClip AwafeMusic;
    public AudioClip LandMusic;

    void Start()
    {
        Music.volume = 0.0f;

    }


    void Update()
    {
        if (fadeIn)
        {
            if (Music.volume <= 0.15)
            {
                Music.volume += fadeInFactor * Time.deltaTime;

            }
        }

        if (fadeOut)
        {
            if (Music.volume >= 0)
            {
                Music.volume -= fadeOutFactor * Time.deltaTime;
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MarketTrigger"))
        {
            Music.clip = MarketMusic;

            if (!Music.isPlaying)
            {
                Music.Play();
            }
            fadeIn = true;
            fadeOut = false;
            print("fadingIn");

        }

        if (other.gameObject.CompareTag("AwafeTrigger"))
        {
            Music.clip = AwafeMusic;

            if (!Music.isPlaying)
            {
                Music.Play();
            }
            fadeIn = true;
            fadeOut = false;
            print("fadingIn");

        }

        if (other.gameObject.CompareTag("LandTrigger"))
        {
            Music.clip = LandMusic;

            if (!Music.isPlaying)
            {
                Music.Play();
            }
            fadeIn = true;
            fadeOut = false;
            print("fadingIn");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MarketTrigger"))
        {

            fadeOut = true;
            fadeIn = false;

        }

        if (other.gameObject.CompareTag("AwafeTrigger"))
        {

            fadeOut = true;
            fadeIn = false;

        }

        if (other.gameObject.CompareTag("LandTrigger"))
        {

            fadeOut = true;
            fadeIn = false;

        }
    }
}