using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinnaeusTalkedTo : MonoBehaviour
{
    public int GetIfLinnaeusSpoke;
    private bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        GetIfLinnaeusSpoke = MotherTalkedTo.TalkedToLinnaeus;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            MotherTalkedTo.TalkedToLinnaeus++;
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
