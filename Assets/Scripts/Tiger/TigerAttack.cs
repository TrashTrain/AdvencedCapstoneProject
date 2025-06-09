using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TigerAttack : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("플레이어 감지");
        if (other.CompareTag("Player") && !transform.parent.GetComponent<Animator>().GetBool("IsRunBack"))
        {
            Debug.Log("공격감지");
            // 슬로우모션
            // GameMgr.Instance.SlowMotion(0.5f);
            //GameMgr.Instance.PlayerInit().SetBoundaryLevel(3);
            transform.parent.GetComponent<Tiger>().isAttack = true;
            transform.parent.GetComponent<Tiger>().tigerState = Tiger.TState.Attack;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("플레이어 감지 종료");
        transform.parent.GetComponent<Tiger>().tigerState = Tiger.TState.Idle;
    }
}
