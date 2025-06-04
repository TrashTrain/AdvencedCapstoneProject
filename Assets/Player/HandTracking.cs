using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public InputActionProperty pinchAnimaionAction;
    public InputActionProperty gripAnimtionAction;

    public Animator HandAnimator;

    void Update()
    {
        float triggerValue = pinchAnimaionAction.action.ReadValue<float>();
        float gripValue = gripAnimtionAction.action.ReadValue<float>();

        HandAnimator.SetFloat("Trigger", triggerValue);
        HandAnimator.SetFloat("Grip", gripValue);
    }
}