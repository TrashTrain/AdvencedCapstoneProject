using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public GameObject CreditPanel;
    // Start is called before the first frame update
    void Start()
    {

        CreditPanel.SetActive(false);
       
    }
    public void manageCreditPanel()
    {
        EventManager.Instance.TriggerEvent("clickSound");
        CreditPanel.SetActive(true);
    }
}
