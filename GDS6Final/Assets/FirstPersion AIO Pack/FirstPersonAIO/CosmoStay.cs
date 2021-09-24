using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CosmoStay : MonoBehaviour
{
    public GameObject ciellepos;
    public GameObject Cosmopos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Cosmopos.transform.position = ciellepos.transform.position + new Vector3(3, 3, 4);

        
        
       
    }
}
