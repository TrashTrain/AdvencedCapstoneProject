using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        if (TestPlayer.isPlayerMove)
            Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 잠금
        else
            Cursor.lockState = CursorLockMode.Confined;
       
    }

    void Update()
    {
        if (TestPlayer.isPlayerMove)
            Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 잠금
        else
            Cursor.lockState = CursorLockMode.Confined;
        if (!TestPlayer.isPlayerMove) return;
        // 마우스 입력
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 위아래 회전 제한
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 카메라 위아래 회전
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 플레이어 좌우 회전
        playerBody.Rotate(Vector3.up * mouseX);
    }
}