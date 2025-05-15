using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetItemManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI item_Name;
    [SerializeField] TextMeshProUGUI item_Text;
    [SerializeField] Image item_Image;
    [SerializeField] GameObject GetItemPanel;


    public void getIteminfo(Item item)
    {
        GetItemPanel.SetActive(true);
        item_Name.SetText(item.itemName);
        item_Text.SetText(item.itemText);
        item_Image.sprite = item.itemGetImage;
    }
    public void exitIteminfo()
    {
        GetItemPanel.SetActive(false);
    }
}
