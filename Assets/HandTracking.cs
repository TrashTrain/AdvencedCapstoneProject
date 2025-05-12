using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public InputActionProperty pinchAnimaionAction;
    public InputActionProperty gripAnimtionAction;

    public Animator HandAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        //Test
        float triggerValue = pinchAnimaionAction.action.ReadValue<float>();
        Debug.Log(triggerValue);
    }
}
