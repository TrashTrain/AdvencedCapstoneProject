using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : MonoBehaviour
{
    // 필요 변수 (호랑이 속도, 움직임 상태, 
    // Start is called before the first frame update
    void Start()
    {
        // 첫 등장은 마을에서 집에서 나온 뒤.(배치 해두고 스토리 이후 시작)
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어 좌표를 향해 일정 속도로 달려오기. -> 플레이어와 일정범위 안으로 가까워지면 점프 공격
        // 곶감에 당했을 때 (도망)

        // 떡을 받았을 때 (심취)
    }

    // 움직임 함수
    private void TigerMove()
    {

    }
    
    // 플레이어 감지 함수
    private void ScanPlayer()
    {

    }
    // 상태 변화 함수(정지, 공격, 정찰)
    public void TigerStateChange()
    {

    }
    // 
}
