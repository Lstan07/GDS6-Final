using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketAmbience : MonoBehaviour
{
    public AudioSource marketsound;
    public float fadeFactor;

    public bool fadeIn = false;
    public bool fadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {
            if(marketsound.volume >= 0.001)
            {
                marketsound.volume -= fadeFactor * Time.deltaTime;
            }
            
        }

        
        if (fadeIn)
        {
            if (marketsound.volume <= 0.07)
            {
                marketsound.volume += fadeFactor * Time.deltaTime;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fadeIn = true;
            fadeOut = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fadeOut = true;
            fadeIn = false;
        }
    }
}
