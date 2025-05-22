using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;
  
    private Item _item;
    public void Start()
    {
        image.sprite = null;
        image.color = new Color(1, 1, 1, 0);
    }
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {   image.sprite = null;
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
  
}
