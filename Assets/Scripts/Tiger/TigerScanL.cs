using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerScanL : MonoBehaviour
{
    public Tiger GetTiger;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("플레이어 감지");
        if (other.CompareTag("Player"))
        {
            GetTiger.TigerStateChanger();
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지중");
            GetTiger.checkRange = 1;
            GetTiger.playerT = other.transform;
            GetTiger.TigerStateChanger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("플레이어 감지 종료");
        GetTiger.tigerState = Tiger.TState.Idle;
    }

}
