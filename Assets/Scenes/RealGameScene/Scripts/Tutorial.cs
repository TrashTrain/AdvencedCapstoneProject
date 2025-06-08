using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialWall;
    public GameObject tutorialMsg;
    public GameObject tutorialEvent;

    public Transform leftDoor;
    public Transform rightDoor;
    public static int tutorialIdx = 0;

    private bool checkClick = false;

    // Update is called once per frame
    void Update()
    {
        if (VRPlayer.instance.menuItemButton.action.WasPressedThisFrame())
        {
            checkClick = true;
        }
        if (tutorialIdx >= 3 && checkClick)
        {
            Destroy(tutorialWall);
            leftDoor.rotation = Quaternion.Lerp(leftDoor.rotation, Quaternion.Euler(0, 20f, 0), 1f * Time.deltaTime);
            rightDoor.rotation = Quaternion.Lerp(rightDoor.rotation, Quaternion.Euler(0, -20f, 0), 1f * Time.deltaTime);
        }
        
        
    }
}
