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
    [SerializeField] GameObject BackGround;
    
   
    
    public void getIteminfo(Item item)
    {
        GetItemPanel.SetActive(true);
        item_Name.SetText(item.itemName);
        item_Text.SetText(item.itemText);
        item_Image.sprite = item.itemGetImage;
        BackGround.gameObject.SetActive(true);
        //DasabaseManager.instance.dialogue.ChangeRayCast();
    }
    public void exitIteminfo()
    {
        GetItemPanel.SetActive(false);
        BackGround.gameObject.SetActive(false);
        //DasabaseManager.instance.dialogue.ChangeRayCast();
    }
}
