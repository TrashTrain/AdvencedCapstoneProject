using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // XR 인터랙션 툴킷을 사용합니다.
using UnityEngine.InputSystem; // 퍼블릭 변수 입력을 위한 입력관리 시스템을 사용합니다.

public class ActiveRay : MonoBehaviour
{
    public GameObject RightTP; // 평선 오브젝트를 퍼블릭 변수로 입력받습니다.

    public InputActionProperty RightActivate; // 오른쪽 트리거 버튼 입력을 받고 값을 얻기 위한 변수

    // Update is called once per frame
    void Update()
    {
        RightTP.SetActive(RightActivate.action.ReadValue<float>() > 0.1f);
        // 오른쪽 트리거 버튼의 입력값이 0.1f보다 크다면 오른쪽 텔레포트 평선 활성화
    }
}

