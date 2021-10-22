using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherTalkedTo : MonoBehaviour
{
    //IMPORTANT NPCS
    public GameObject SanarbiaOne;
    public GameObject SanarbiaTwo;
    public static int TalkedToFynn = 0;
    public static int TalkedToAlmoira = 0;
    public static int TalkedToLinnaeus = 0;

    //GATEKEEPERS
    public GameObject FynnBlockerLeft;
    public GameObject FynnBlockerRight;
    public GameObject AlmoiraBlockers;
    public GameObject LinnaeusBlockers;
    public GameObject SanarbiaBlockerLeft;
    public GameObject SanarbiaBlockerRight;
    public GameObject SanarbiaBlockerBack;
    public static int TalkedToBrig = 0;
    public static int TalkedToReagan = 0;
    public static int TalkedToTella = 0;
    public static int TalkedToSanarbia = 0;

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

        if (TalkedToBrig >= 1)
        {
            LinnaeusBlockers.SetActive(false);
        }

        if (TalkedToReagan >= 1)
        {
            FynnBlockerLeft.SetActive(false);
            FynnBlockerRight.SetActive(false);
        }

        if (TalkedToTella >= 1)
        {
            AlmoiraBlockers.SetActive(false);
        }

        if (TalkedToSanarbia >= 1)
        {
            SanarbiaBlockerBack.SetActive(false);
            SanarbiaBlockerLeft.SetActive(false);
            SanarbiaBlockerRight.SetActive(false);
        }
    }
}