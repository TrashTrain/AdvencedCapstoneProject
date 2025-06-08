using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMeet : MonoBehaviour
{
    public GameObject tiger;


    private void OnTriggerEnter(Collider other)
    {
        if (!tiger.GetComponent<Tiger>().enabled)
        {
            tiger.GetComponent<Tiger>().enabled = true;
            //tiger.transform.GetChild(0).gameObject.SetActive(true);
            //tiger.transform.GetChild(1).gameObject.SetActive(true);
            tiger.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    
}
