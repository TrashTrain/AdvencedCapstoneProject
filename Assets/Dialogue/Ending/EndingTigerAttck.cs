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
            // 슬로우모션
            // GameMgr.Instance.SlowMotion(0.5f);
            GameMgr.Instance.PlayerInit().SetBoundaryLevel(3);
            GetTiger.TigerStateChanger();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지중");
            GetTiger.TigerStateChanger();

            GetTiger.playerT = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("플레이어 감지 종료");
        GetTiger.tigerState = EndingTiger.TState.Idle;
    }
}
