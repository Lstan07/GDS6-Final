using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FynnTalkedTo : MonoBehaviour
{
    public int GetIfFynnSpoke;
    private bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        GetIfFynnSpoke = MotherTalkedTo.TalkedToFynn;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            MotherTalkedTo.TalkedToFynn++;
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
