using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanel : MonoBehaviour
{
    public GameObject Credit;
    // Start is called before the first frame update
   public void exitCredit()
    {
        EventManager.Instance.TriggerEvent("clickSound");
        Credit.SetActive(false);
    }
}
