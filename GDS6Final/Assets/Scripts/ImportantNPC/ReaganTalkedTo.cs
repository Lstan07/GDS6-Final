using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaganTalkedTo : MonoBehaviour
{
    public int GetIfReaganSpoke;
    private bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        GetIfReaganSpoke = MotherTalkedTo.TalkedToReagan;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            MotherTalkedTo.TalkedToReagan++;
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
