using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWhiteFade : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fadeImage1;
    public float timeLeft = 0f;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fadeImage1.color = Color.Lerp(fadeImage1.color, Color.white, 1f * Time.deltaTime);


      

    }
}
