using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMother : MonoBehaviour
{
    public GameObject Oil;
    public GameObject Meal;
    public GameObject Ball;
    public GameObject AllDone;
    public static int ImportantTotal = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ImportantTotal = " + ImportantTotal);
        if (ImportantTotal >= 3)
        {
            AllDone.SetActive(true);
        }
    }


}