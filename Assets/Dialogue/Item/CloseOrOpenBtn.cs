using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseOrOpenBtn : MonoBehaviour
{   public Button CloseButton;
    public Button OpenButton;
    public GameObject Inventory;
    bool isOpen;
    void Start()
    {
        isOpen = true;
        CloseButton.gameObject.SetActive(true);
        OpenButton.gameObject.SetActive(false);
    }
    public void CloseOrOpen()
    {
        if (isOpen) 
        {
            Inventory.SetActive(false);
        }
    }


  
}
