using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigTalkedTo : MonoBehaviour
{
    public int GetIfBrigSpoke;
    private bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        GetIfBrigSpoke = MotherTalkedTo.TalkedToBrig;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            MotherTalkedTo.TalkedToBrig++;
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
