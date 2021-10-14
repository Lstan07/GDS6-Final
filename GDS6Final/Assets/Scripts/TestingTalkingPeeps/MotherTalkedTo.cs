using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherTalkedTo : MonoBehaviour
{
    public GameObject SanarbiaOne;
    public GameObject SanarbiaTwo;
    public static int TalkedToFynn = 0;
    public static int TalkedToAlmoira = 0;
    public static int TalkedToLinnaeus = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TalkedToFynn >= 1 && TalkedToAlmoira >= 1 && TalkedToLinnaeus >= 1)
        {
            SanarbiaTwo.SetActive(true);
            SanarbiaOne.SetActive(false);
        }
    }
}