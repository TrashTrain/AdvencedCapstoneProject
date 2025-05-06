using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerAttack : MonoBehaviour
{
    public Tiger GetTiger;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("플레이어 감지");
        if (other.CompareTag("Player"))
        {
            // 슬로우모션
            // GameMgr.Instance.SlowMotion(0.5f);
            GetTiger.tigerState = Tiger.TState.Attack;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GetTiger.tigerState != Tiger.TState.Attack)
                GetTiger.tigerState = Tiger.TState.Attack;
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
