using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmoMovement : MonoBehaviour
{
    public GameObject CiellePlayer; //defining cielle
    public float TargetDistance; //seeing how far cielle is from cosmo
    public float AllowedDistance = 3; //how close we want cosmo to get
    public GameObject CosmoNPC; //defining cosmo
    public float FollowSpeed; // the speed we want cosmo to zoom at
    public RaycastHit Shot; //raycast detection
    public GameObject CosmoLookAt;

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(CosmoLookAt.transform);
        // if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Shot))
        //{
        TargetDistance = Shot.distance; //relating cielles in the scene to the distance cosmo needs to target 
                                        // if (TargetDistance >= AllowedDistance) //if cielle is further away than where cosmo can be
                                        //{
        FollowSpeed = 0.012f; //this is cosmos speed
                            //if we wanted a run animation, it would be here with: CosmoNPC.GetComaponent<Animation>().Play("NAMEOFANI");
        transform.position = Vector3.MoveTowards(transform.position, CiellePlayer.transform.position, FollowSpeed); //zoom towards cielle's position at the speed                                                                                                             //  }
       //else
       //{
       //  FollowSpeed = 0; //if were in the range, stop moving
       //if we wanted an idle animation then: CosmoNPC.GetComponent<Animation>().Play("NAMEOFANI")
       //}
       //}
    }
}
