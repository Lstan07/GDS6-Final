using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    public int GetTotalValue;


    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseDown()
    {
        CollectMother.ImportantTotal++;
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetTotalValue = CollectMother.ImportantTotal;
    }

   

}
