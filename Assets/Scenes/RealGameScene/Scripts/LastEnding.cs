using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastEnding : MonoBehaviour
{
    public bool inPlayer = false;
    private void OnTriggerEnter(Collider other)
    {
        inPlayer = true;
    }
}
