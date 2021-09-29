using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueNPC : MonoBehaviour
{

    //public Canvas dialogueCanvas;
   // public Image dialogueBox;
    //public Text dialogueText;
    //public Button nextButton;
    //public VerticalLayoutGroup choicesButton;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        // dialogueBox.enabled = false;
        //dialogueText.enabled = false;
        //nextButton.enabled = false;
        //choicesButton.enabled = false;

       // dialogueCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialogue()
    {
        // dialogueBox.enabled = true;
        // dialogueText.enabled = true;
        // nextButton.enabled = true;
        // choicesButton.enabled = true;

        //dialogueCanvas.enabled = true;

        playerObject.GetComponent<FirstPersonAIO>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideDialogue()
    {
        //dialogueBox.enabled = false;
        //dialogueText.enabled = false;
        //nextButton.enabled = false;
        //choicesButton.enabled = false;

       // dialogueCanvas.enabled = false;

        playerObject.GetComponent<FirstPersonAIO>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
