using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class RayInteratopnEvent : MonoBehaviour
{
    public XRRayInteractor xri;

    void Start()
    {
        xri.selectEntered.AddListener(SelectEnterEvent);
        xri.selectExited.AddListener(SelectExitEvent);
    }

    private void SelectEnterEvent(SelectEnterEventArgs args)
    {
        Debug.Log("Selected Enter");
    }

    private void SelectExitEvent(SelectExitEventArgs args)
    {
        Debug.Log("Selected Exit");
    }
}
