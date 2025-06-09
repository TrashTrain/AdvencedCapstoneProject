using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMeet : MonoBehaviour
{
    public GameObject tiger;
    public GameObject door;

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

    private void Update()
    {
        door.transform.rotation = Quaternion.Lerp(door.transform.rotation, Quaternion.Euler(0, 20f, 0), 1f * Time.deltaTime);

        Destroy(gameObject, 3);
    }

}
