using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootItemManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
  
   public void UseGam()
    {
        inventory.UseItem("°ù°¨");
    }
   public void UseDduck()
    {
        inventory.UseItem("¶±");
    }


}
