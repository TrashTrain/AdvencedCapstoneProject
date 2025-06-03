using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bell : MonoBehaviour
{
    public GameObject canvas;
    public Inventory inven;
    public Item bell;

    void Update()
    {
        //canvas
        if(Tutorial.tutorialIdx >= 2)
        {
            canvas.SetActive(true);
        }
        if (canvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inven.AddItem(bell);
                Destroy(gameObject);
            }
        }
    }

    // vr »Æ¿Œ
    public void OnGribBell()
    {
        inven.AddItem(bell);
    }
}
