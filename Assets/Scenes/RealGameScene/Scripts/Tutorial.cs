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


    // Update is called once per frame
    void Update()
    {
        if(tutorialIdx >= 3)
        {
            leftDoor.rotation = Quaternion.Lerp(leftDoor.rotation, Quaternion.Euler(0, 20f, 0), 1f * Time.deltaTime);
            rightDoor.rotation = Quaternion.Lerp(rightDoor.rotation, Quaternion.Euler(0, -20f, 0), 1f * Time.deltaTime);
            Destroy(tutorialEvent);
        }
        
        
    }
}
