using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellaTalkedTo : MonoBehaviour
{
    public int GetIfTellaSpoke;
    private bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        GetIfTellaSpoke = MotherTalkedTo.TalkedToTella;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            MotherTalkedTo.TalkedToTella++;
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
