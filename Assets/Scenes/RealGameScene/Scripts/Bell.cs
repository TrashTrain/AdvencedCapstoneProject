using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bell : MonoBehaviour
{
    public GameObject canvas;
    public Inventory inven;
    public Item bell;
    public GameObject dialog;

    private void Start()
    {
        if (dialog == null)
            dialog = gameObject;
        if (bell == null)
            Destroy(gameObject);
    }

    void Update()
    {
        if (dialog == gameObject)
        {
            canvas.SetActive(true);
            return;
        }
        //canvas
        if (Tutorial.tutorialIdx >= 2 && dialog.GetComponent<InteractionEvent>().tutorial)
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
        Destroy(gameObject);
        //DasabaseManager.instance.dialogue.ChangeRayCast();
    }

}
