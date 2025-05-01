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
            GetTiger.tigerState = Tiger.TState.Attack;

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
