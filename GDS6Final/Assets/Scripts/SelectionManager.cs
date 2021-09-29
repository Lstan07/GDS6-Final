using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    //[SerializeField] private string selectableTag = "Selectable";
    //[SerializeField] private Material highlightMaterial;
    //[SerializeField] private Material defaultMaterial;

    //private Transform _selection;

    public string interactButton;
    public LayerMask interactLayer;
    public Image interactIcon;
    public bool isInteracting;
    public float interactDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        if (interactIcon != null)
        {
            interactIcon.enabled = false;
        }
         
    }

    // Update is called once per frame
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            
            if(isInteracting == false)
            {
                if (interactIcon != null)
                {
                    interactIcon.enabled = true;
                }
                

                if (Input.GetButtonDown(interactButton))
                {
                    if (hit.collider.CompareTag("NPC"))
                    {
                        hit.collider.GetComponent<DialogueNPC>().ShowDialogue();
                    }
                }
            }
        }
        else
        {
            interactIcon.enabled = false;
        }
    }
}
