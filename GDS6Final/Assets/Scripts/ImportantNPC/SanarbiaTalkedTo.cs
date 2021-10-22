using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanarbiaTalkedTo : MonoBehaviour
{
    public int GetIfSanarbiaSpoke;
    private bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        GetIfSanarbiaSpoke = MotherTalkedTo.TalkedToSanarbia;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            MotherTalkedTo.TalkedToSanarbia++;
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
