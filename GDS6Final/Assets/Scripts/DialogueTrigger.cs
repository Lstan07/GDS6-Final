using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;


public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    public string interactButton;

    //public bool CosmoShouldTurn; //SDFGHGGHGVDJSHVSVJSVHVSJCVSJDVDSVDD\SHCVSJVCSVCHJSVCHJSCVSHCVSJCVJCHVSJCV

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !InkDialogueManager.GetInstance().dialogueIsPlaying)
        {
            
            visualCue.SetActive(true);
            if (Input.GetButtonDown(interactButton))
            {
               

                InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);


            }

        } else
        {
            visualCue.SetActive(false);
        }

        //CosmoShouldTurn = CosmoRotate.isTalking; //sjkdgaksjdgkjsgdjkasgdkjsgdjkgsakjgsdkjgsdkjgsakdjgksajgdaksgdajk
    }

    private void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            Debug.Log("what is going on bitch");
            playerInRange = true;
            //CosmoRotate.isTalking = true; //akshakhskahskahskahskahksahskhakshsjdhjfgsjdsjdhjaskasakhsakhsakhs
        }
    }

    private void OnTriggerExit (Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            //CosmoRotate.isTalking = false; // adhkahdkahdkhdkahdkhakhkahdkahdkahdkahkahdkahdkah
        }
    }
}
