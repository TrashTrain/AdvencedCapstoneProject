using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMgr : MonoBehaviour
{
    public GameObject rayController;

    public Transform startTf;
    private RaycastHit hitInfo;
    private Color color;

    // Event function
    void Update()
    {
        if (Physics.Raycast(startTf.position, startTf.forward, out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.tag == "UI")
            {
                rayController.SetActive(true);
            }
            else
            {
                rayController.SetActive(false);
            }
        }
        else
        {
            rayController.SetActive(false);
        }
    }
}
