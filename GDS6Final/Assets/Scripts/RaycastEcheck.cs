using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEcheck : MonoBehaviour
{
    public float sphereRadius;
    //public AudioSource songy;
    //public float fadetalk;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(this.transform.position, sphereRadius, this.transform.forward * 5, out hit, 7))
        {
            if (hit.transform.name == "SanarbiaFirst")
            {
                //Debug.Log("Looking at Sanarbia");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //songy.volume -= fadetalk * Time.deltaTime;
                    
                    MotherTalkedTo.TalkedToSanarbia++;
                    print(MotherTalkedTo.TalkedToSanarbia);

                }

            }

            if (hit.transform.name == "ThisIsBrig")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MotherTalkedTo.TalkedToBrig++;
                    print(MotherTalkedTo.TalkedToBrig);
                   
                }
            }

            if (hit.transform.name == "ThisIsRaegan")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MotherTalkedTo.TalkedToReagan++;
                    print(MotherTalkedTo.TalkedToReagan);
                }
            }

           
            if (hit.transform.name == "ThisIsFynn")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MotherTalkedTo.TalkedToFynn++;
                    print(MotherTalkedTo.TalkedToFynn);
                }
            }

            if (hit.transform.name == "ThisIsTella")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MotherTalkedTo.TalkedToTella++;
                    print(MotherTalkedTo.TalkedToTella);
                }
            }

            if (hit.transform.name == "ThisIsLinnaeus")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MotherTalkedTo.TalkedToLinnaeus++;
                    print(MotherTalkedTo.TalkedToLinnaeus);
                }
            }

            if (hit.transform.name == "ThisIsAlmoira")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MotherTalkedTo.TalkedToAlmoira++;
                    print(MotherTalkedTo.TalkedToAlmoira);
                }
            }
        }
    }
}
