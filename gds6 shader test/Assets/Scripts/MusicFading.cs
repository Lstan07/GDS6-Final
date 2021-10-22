using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MusicFading : MonoBehaviour {


     public AudioSource Music;

    public float fadeInFactor = 0.01f;
    public float fadeOutFactor = 0.03f;

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

    
    void OnTriggerEnter (Collider other)
    {
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
                
            

        }
    }    
 }