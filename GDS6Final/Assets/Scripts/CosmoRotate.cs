using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmoRotate : MonoBehaviour
{
    float rotationAngle;
    bool still = true;
    public GameObject Cosmo;
    Vector3 tation;
    public GameObject CosmoLook;
    public GameObject Cielle;
    private Rigidbody rb;
    public static bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
       // tation = new Vector3 (0, 90, 0);
    }


    // Update is called once per frame
    void Update()
    {


        //Vector3 speed = cielle.velocity;
        rb = gameObject.GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
        {
            if (isTalking == true)
            {
                still = true;

                //print("asswipe");
            }

            if (isTalking == false)
            {
                still = false;
            }
        }
        else
        {
            still = false;
        }

        if (still == true)
        {
            Cosmo.transform.LookAt(Cielle.transform);

        }

        if (still == false)
        {
            Cosmo.transform.LookAt(CosmoLook.transform);
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
      //  isTalking = true;
    //}

    //private void OnTriggerExit(Collider other)
    //{
      //  isTalking = false;
    //}
}
