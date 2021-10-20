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

 
    public LayerMask interactLayer;
    public Image interactIcon;
    public bool isInteracting;
    public float interactDistance = 3f;
    public GameObject fadeImage;
    public float timeLeft = 0f;

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
        Interaction();
    }

    public void Interaction()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;



        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            
            if (hit.collider.CompareTag("NPC"))
            {  
                
                if (isInteracting == false)
                {
                    if (interactIcon != null)
                    {

                    interactIcon.enabled = true;

                    }

                }



            }

            if (hit.collider.CompareTag("EndBall"))
            {

                if (isInteracting == false)
                {
                    if (interactIcon != null)
                    {

                        interactIcon.enabled = true;

                    }

                }

                if (Input.GetKey(KeyCode.E))
                {

                    fadeImage.SetActive(true);

                   

                }
                
            }

         
        }
        else
        {
            interactIcon.enabled = false;
        }
    }
}
