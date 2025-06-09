using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    private float waitTime = 2;
    private float currentTime = 0f;
    private float destroyTime = 5f;


    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= waitTime)
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        if (currentTime >= destroyTime)
            Destroy(gameObject);
    }
}
