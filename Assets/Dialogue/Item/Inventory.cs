using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Item testitem;
    public Item testitem2;
    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;
    [SerializeField] private GetItemManager getItemManager;
    [SerializeField] TextMeshProUGUI GamQuantityText;
    [SerializeField] TextMeshProUGUI DduckQuantityText;
#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    void Awake()
    {
        //FrestSlot();
    }
    public void Start()
    {
        //AddItem(testitem);
        //AddItem(testitem);
        //AddItem(testitem2);
        //AddItem(testitem2);
    }

    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
        Item ggotgam = items.Find(item => item.itemName == "°ù°¨");
        GamQuantityText.text = ggotgam != null ? ggotgam.quantity.ToString() : "0";

        Item Dduck = items.Find(item => item.itemName == "¶±");
        DduckQuantityText.text = Dduck != null ? Dduck.quantity.ToString() : "0";
    }

    public void AddItem(Item _item)
    {
        if (_item.isStack)
        {
            Item existingItem = items.Find(i => i.itemName == _item.itemName);
            if (existingItem != null)
            {
                existingItem.quantity++;
            }
            else
            {

                _item.quantity = 1;
                items.Add(_item);
            }
        }
        else
        {
            if (items.Count < slots.Length)
            {
                _item.quantity = 1;
                items.Add(_item);
            }
            else
            {

                print("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
                return;
            }
        }
        FreshSlot();

        if (getItemManager != null)
        {
            getItemManager.getIteminfo(_item);
        }

    }
    public void UseItem(string itemName)
    {
        Item targetItem = items.Find(item => item.itemName == itemName);
        
        if (targetItem != null && targetItem.isStack)
        {
            targetItem.quantity--;

            if (targetItem.quantity <= 0)
            {
                items.Remove(targetItem);
            }
            FreshSlot();
        }
       

    }
}
