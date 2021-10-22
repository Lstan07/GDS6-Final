using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OutroFade : MonoBehaviour
{

    public Image fadeImage;
    public float timeLeft = 0;
    public GameObject Goodbye;
    public GameObject GoAwayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.black, 1f * Time.deltaTime);




        timeLeft += Time.deltaTime; //timer to end the game after monologue
        if (timeLeft > 10f)
        {

            SceneManager.LoadScene("TitleScene");
           
        }
        if (timeLeft > 3f)
        {

            Goodbye.SetActive(true);

        }
        if (timeLeft > 6f)
        {

            GoAwayText.SetActive(true);
        }

    }
}
