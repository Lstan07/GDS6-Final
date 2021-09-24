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
    //public GameObject cielle;

    // Start is called before the first frame update
    void Start()
    {
       // tation = new Vector3 (0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {

        Rigidbody cielle = GetComponent<Rigidbody>();
        //Vector3 speed = cielle.velocity;

        if (cielle.velocity.magnitude > 0)

        {
            still = false;
            print("asswipe");
            
        }
        else
        {
            still = true;
        }
       
        if (still == true) 
        {
            Cosmo.transform.LookAt(cielle.transform);   
             
        }

        if (still == false)
        {
            Cosmo.transform.LookAt(CosmoLook.transform);
       }
    }
}
