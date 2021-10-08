using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MusicFading : MonoBehaviour {


     public AudioSource Music;

public float fadeFactor = 0.01f;

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
                Music.volume += fadeFactor * Time.deltaTime;
                print("fadeIn");
            }
        }

        if (fadeOut)
        {
            if (Music.volume >= 0)
            {
                Music.volume -= fadeFactor * Time.deltaTime;
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
                print("why");
            

        }
    }    
 }