using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class CustomGrabMgr : XRGrabInteractable
{
    public Transform left_grab_transform;
    public Transform right_grab_transform;

    void Start()
    {
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("Left Hand"))
        {
            this.attachTransform = left_grab_transform;
        }
        else if (interactor.CompareTag("Right Hand"))
        {
            this.attachTransform = right_grab_transform;
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
    }

    protected override void OnActivate(XRBaseInteractor interactor)
    {
    }
}
