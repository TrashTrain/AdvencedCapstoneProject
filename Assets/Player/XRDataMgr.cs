using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class XRDataMgr : MonoBehaviour
{
    public InputActionAsset inputActionAsset;

    public Text textUI;
    public Text textUI1;
    public Text textUI2;

    // Event function
    void Update()
    {
        var hmdPosition = inputActionAsset.actionMaps[0].actions[0].ReadValue<Vector3>();
        var rightContPosition = inputActionAsset.actionMaps[4].actions[0].ReadValue<Vector3>();
        var leftContTrigger = inputActionAsset.actionMaps[2].actions[2].ReadValue<float>();

        textUI.text = hmdPosition.ToString();
        textUI1.text = rightContPosition.ToString();
        textUI2.text = leftContTrigger.ToString();
    }
}
