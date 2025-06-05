using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void exit()
    {
        EventManager.Instance.TriggerEvent("clickSound");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // ���ø����̼� ����
        #endif
    }
}
