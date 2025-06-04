using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<Item> stack_items = new List<Item>();
    public Item testitem;
    public Item testitem2;
    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;
    [SerializeField] private GetItemManager getItemManager;
    [SerializeField] TextMeshProUGUI GamQuantityText;
    [SerializeField] TextMeshProUGUI DduckQuantityText;

    private Item ggotgam;
    private Item Dduck;

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
        ggotgam = testitem;//items.Find(item => item.itemName == "°ù°¨");
        GamQuantityText.text = ggotgam != null ? ggotgam.quantity.ToString() : "0";

        Dduck = testitem2;
        DduckQuantityText.text = Dduck != null ? Dduck.quantity.ToString() : "0";
    }

    public void AddItem(Item _item)
    {
        if (_item.isStack)
        {
            Item existingItem = stack_items.Find(i => i.itemName == _item.itemName);
            
            if (existingItem != null)
            {
                existingItem.quantity++;
            }
            else
            {

                _item.quantity = 1;
                stack_items.Add(_item);

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
        Item target_stack_Item=stack_items.Find(item => item.itemName == itemName);
        if (target_stack_Item != null)
        {
            target_stack_Item.quantity--;

            if (target_stack_Item.quantity <= 0)
            {
                stack_items.Remove(target_stack_Item);
            }
            FreshSlot();
        }
        if (targetItem != null)
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
