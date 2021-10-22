using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmoiraTalkedTo : MonoBehaviour
{
    public int GetIfAlmoiraSpoke;
    private bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        GetIfAlmoiraSpoke = MotherTalkedTo.TalkedToAlmoira;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            MotherTalkedTo.TalkedToAlmoira++;
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
