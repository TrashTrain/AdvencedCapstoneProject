using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerScanS : MonoBehaviour
{
    public Tiger GetTiger;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("플레이어 감지");
        if (other.CompareTag("Player"))
        {
            if (GameMgr.Instance.PlayerInit().GetBoundaryLevel() >= 1)
            {
                GetTiger.tigerState = Tiger.TState.Run;
            }
            else
            {
                GetTiger.tigerState = Tiger.TState.Idle;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지중");
            GetTiger.playerT = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("플레이어 감지 종료");
        GetTiger.tigerState = Tiger.TState.Idle;
    }

}
