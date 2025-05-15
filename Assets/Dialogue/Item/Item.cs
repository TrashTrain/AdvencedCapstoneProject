using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemText;
    public Sprite itemImage;
    public Sprite itemGetImage;
    public bool isStack;
    public int quantity=0;

}