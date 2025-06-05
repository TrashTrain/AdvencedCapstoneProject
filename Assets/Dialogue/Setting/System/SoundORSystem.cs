using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundORSystem : MonoBehaviour
{
    public GameObject SoundTab;
    public GameObject SystemTab;

    public Image SoundTabImage;
    public Image SystemTabImage;

    private Color soundTabOriginalColor;
    private Color systemTabOriginalColor;

    public float darkenFactor = 0.6f;
    private void Awake() 
    {
       
        

        // ���� ������ ����
        if (SoundTabImage != null) 
            soundTabOriginalColor = SoundTabImage.color;
        if (SystemTabImage != null)
            systemTabOriginalColor = SystemTabImage.color;
        
    }

    private void Start()
    {
        SoundTab.SetActive(true);
        SystemTab.SetActive(false);
        if (SystemTabImage != null)
            SystemTabImage.color = systemTabOriginalColor * darkenFactor;
        if (SoundTabImage != null)
            SoundTabImage.color = soundTabOriginalColor;
    }
    public void setSystemTab()
    {
        EventManager.Instance.TriggerEvent("clickSound");
        SystemTab.SetActive(true);
        SoundTab.SetActive(false);
        if (SystemTabImage != null)
            SystemTabImage.color = systemTabOriginalColor;
        if (SoundTabImage != null)
            SoundTabImage.color = soundTabOriginalColor * darkenFactor;
    }
    public void setSoundTab()
    {
        EventManager.Instance.TriggerEvent("clickSound");
        SystemTab.SetActive(false);
        SoundTab.SetActive(true);
        if (SystemTabImage != null)
            SystemTabImage.color = systemTabOriginalColor * darkenFactor;
        if (SoundTabImage != null)
            SoundTabImage.color = soundTabOriginalColor;
    }
}
