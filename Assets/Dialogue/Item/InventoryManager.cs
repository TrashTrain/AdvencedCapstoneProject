using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject fullInventoryUI; 
    [SerializeField] private GameObject miniSlotUI;     

    [SerializeField] private Inventory inventory;        
    [SerializeField] private Slot miniSlot;
    [SerializeField] private Button close_btn;
    [SerializeField] private Button open_btn;

    public void OpenInventory()
    {
        EventManager.Instance.TriggerEvent("clickSound");
        fullInventoryUI.SetActive(true);
        miniSlotUI.SetActive(false);
        open_btn.gameObject.SetActive(false);
        close_btn.gameObject.SetActive(true);
       
    }

    public void CloseInventory()
    {
        EventManager.Instance.TriggerEvent("clickSound");
        fullInventoryUI.SetActive(false);
        miniSlotUI.SetActive(true);
        open_btn.gameObject.SetActive(true);
        close_btn.gameObject.SetActive(false);
       
       
        // 첫 번째 아이템 가져와서 반영
        if (inventory.items.Count > 0)
        {
            miniSlot.item = inventory.items[0];
        }
        else
        {
            miniSlot.item = null;
        }
    }
}
