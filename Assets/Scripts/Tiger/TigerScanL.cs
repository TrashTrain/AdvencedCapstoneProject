using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerScanL : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("플레이어 감지");
        if (other.CompareTag("Player"))
        {
            Tiger.tigerState = Tiger.TState.Idle;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지중");
            Tiger.playerT = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("플레이어 감지 종료");
        Tiger.tigerState = Tiger.TState.Idle;
    }

}
