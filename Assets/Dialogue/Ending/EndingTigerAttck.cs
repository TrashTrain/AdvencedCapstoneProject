using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTigerAttck : MonoBehaviour
{
    public EndingTiger GetTiger;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("플레이어 감지");
        if (other.CompareTag("Player"))
        {
            GetTiger.tigerState = EndingTiger.TState.Attack;
        }
    }

}
