using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneBG : MonoBehaviour
{
    public float parallaxIntensity = 30f; // 픽셀 단위 움직임
    public Vector2 maxOffset = new Vector2(50f, 30f); // 최대 이동 제한 (픽셀)

    private RectTransform rectTransform;
    private Vector2 initialAnchoredPosition;

    private Vector3 initialPosition;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialAnchoredPosition = rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBGMouse();
    }

    public void MoveBGMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        // 뷰포트 좌표 기준 (0~1), 중심은 (0.5, 0.5)
        Vector2 normalized = new Vector2(mousePos.x / screenSize.x - 0.5f, mousePos.y / screenSize.y - 0.5f);

        // 이동 벡터 계산
        Vector2 offset = normalized * parallaxIntensity;

        // 이동 범위 제한
        offset.x = Mathf.Clamp(offset.x, -maxOffset.x, maxOffset.x);
        offset.y = Mathf.Clamp(offset.y, -maxOffset.y, maxOffset.y);

        rectTransform.anchoredPosition = initialAnchoredPosition + offset;
    }
}
